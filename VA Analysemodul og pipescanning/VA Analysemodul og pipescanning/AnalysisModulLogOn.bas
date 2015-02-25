Attribute VB_Name = "AnalysisModulLogOn"

Dim WG_brukernavn As Variant


Public Function CheckUserRight_NewModel()

Dim ModelOwner As Variant

CheckUserRight_NewModel = False

ModelOwner = VAanalyseModul_DesignDialog.ModelOwner.Value

If IsNull(ModelOwner) Or ModelOwner = "" Then
    MsgBox "ModelOwner ikke angitt. Kan ikke lagre endringer.", vbExclamation
    Exit Function
End If

If ModelOwner = WG_brukernavn Then CheckUserRight_NewModel = True

End Function


Public Function CheckUserRight() As Boolean

Dim ModelOwner As Variant
Dim ModelID As Variant

CheckUserRight = False

ModelID = VAanalyseModul_DesignDialog.ModelID.Value

If IsNull(ModelID) Or ModelID = "" Then
    MsgBox "ModelID ikke angitt. Kan ikke lagre endringer.", vbExclamation
    Exit Function
End If

ModelOwner = GetModelOwnerFromDatabase(ModelID)

If IsNull(ModelOwner) Or ModelOwner = "" Then
    MsgBox "ModelOwner ikke angitt. Kan ikke lagre endringer.", vbExclamation
    Exit Function
End If

If ModelOwner = WG_brukernavn Then CheckUserRight = True

End Function


Public Function GetModelOwnerFromDatabase(ModelID As Variant) As Variant

Dim pStandaloneTable As IStandaloneTable
Dim pTable As ITable
Dim pRow As IRow
Dim pCursor As ICursor
Dim pQueryFilter As IQueryFilter

GetModelOwnerFromDatabase = Null

Set pStandaloneTable = HentStdAloneTabellFraTOC("AnalysisModel")
Set pTable = pStandaloneTable.Table
Set pQueryFilter = New QueryFilter

pQueryFilter.WhereClause = "MODELID = " & """" & ModelID & """"
Set pCursor = pTable.Search(pQueryFilter, False)
Set pRow = pCursor.NextRow

If Not pRow Is Nothing Then
    GetModelOwnerFromDatabase = pRow.Value(pRow.Fields.FindField("MODELOWNER"))
End If

End Function

Public Function Paalogging() As Boolean

Dim pStandaloneTable As IStandaloneTable
Dim pTable As ITable
Dim pRow As IRow
Dim pQueryFilter As IQueryFilter
Dim Brukernavn As Variant

Paalogging = False
Brukernavn = Null
WG_brukernavn = Null

Set pStandaloneTable = HentStdAloneTabellFraTOC("Users")
Set pTable = pStandaloneTable.Table
Set pQueryFilter = New QueryFilter

AngiBruker:
Brukernavn = InputBox("Brukernavn:", "Pålogging")

'Sjekk om Brukernavn er i brukernavn tabell ("WG_brukere")

If Not IsNull(Brukernavn) And Brukernavn <> "" Then

    pQueryFilter.WhereClause = "USERNAME = " & """" & Brukernavn & """"

    If pTable.RowCount(pQueryFilter) = 0 Then
        MsgBox "Angitt bruker er ikke definert i brukerliste!", vbExclamation
        GoTo AngiBruker
    Else
        Paalogging = True
    End If
    
End If

WG_brukernavn = Brukernavn

Set pTable = Nothing
Set pStandaloneTable = Nothing

End Function


Public Function HentBrukernavn() As Variant
HentBrukernavn = WG_brukernavn
End Function


Public Sub AnalysisModulLogout()
WG_brukernavn = Null
End Sub


Public Sub VerifiserBrukernavn()

Dim Brukernavn As Variant

Brukernavn = HentBrukernavn

If IsNull(Brukernavn) Or Brukernavn = "" Then

Paalogging:
    If Paalogging = False Then
    
        If MsgBox("Pålogging feilet! Prøv på nytt?", vbExclamation + vbOKCancel) = vbOK Then
            GoTo Paalogging
        End If
    
        For Each UserForm In UserForms
            For Each Control In UserForm.Controls
                Control.Enabled = False
            Next Control
        Next UserForm

    End If

End If

End Sub



Public Sub ShowUserName()
On Error GoTo Err_Feil

Brukernavn = HentBrukernavn

If IsNull(Brukernavn) Or Brukernavn = "" Then Exit Sub

For Each UserForm In UserForms
    If UserForm.Name = "VAanalyseModul_DesignDialog" Then
        VAanalyseModul_DesignDialog.UserName.Caption = "User: " & Brukernavn
    End If
Next UserForm

Exit_Feil:
    Exit Sub
Err_Feil:
    MsgBox Err.Description
    Resume Exit_Feil
End Sub
