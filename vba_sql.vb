Option Explicit

Private version_sql         As String
Private date_sql            As Date

Public Function CompareVersions() As Boolean

    If Me.DateSQL = Me.DateWorkbook And Me.VersionSQL = Me.VersionWorkbook Then
        CompareVersions = True
    Else
        CompareVersions = False
    End If

End Function

Public Function PostInfo() As String

    PostInfo = "Diese Version ist " & Me.VersionWorkbook & " von " & Me.DateWorkbook & "." & vbCrLf & _
                "Die letzte ist " & Me.VersionSQL & " von " & Me.DateSQL & "."

End Function

Public Property Get VersionWorkbook() As String

    VersionWorkbook = [set_version_number]

End Property

Public Property Get DateWorkbook() As Date
    
    DateWorkbook = [set_version_date]

End Property

Public Property Get VersionSQL() As String
    
    VersionSQL = version_sql
    
End Property

Public Property Get DateSQL() As Date
    
    DateSQL = date_sql

End Property

Public Sub CheckDataInSQLServer()

    Dim cnLogs              As Object
    Dim rsData              As Object
    
    Dim l_counter           As Long
    
    On Error GoTo CheckDataInSQLServer_Error
   
    Set cnLogs = CreateObject("ADODB.Connection")
    Set rsData = CreateObject("ADODB.Recordset")

    cnLogs.Open str_connection_string
    cnLogs.Execute "SET NOCOUNT ON"


    rsData.ActiveConnection = cnLogs
    rsData.Open "SELECT [CountTimesUsed] FROM [UsageCounter] WHERE DateUsed = cast(GETDATE() as DATE);"
        
    If rsData.EOF Then
        rsData.Close
        rsData.Open "INSERT INTO [UsageCounter] (DateUsed, CountTimesUsed) VALUES (cast(GETDATE() as DATE), 1)"
    Else
        l_counter = rsData.Fields("CountTimesUsed").Value + 1
        rsData.Close
        rsData.Open "UPDATE [UsageCounter] SET [CountTimesUsed] = " & l_counter & " WHERE DateUsed = cast(GETDATE() as DATE);"
    End If

    cnLogs.Close
    
    Set cnLogs = Nothing
    Set rsData = Nothing
    
    On Error GoTo 0
    Exit Sub

CheckDataInSQLServer_Error:

    Debug.Print "Error " & Err.Number & " (" & Err.Description & ") in procedure CheckDataInSQLServer of Sub cls_Version"
    Set cnLogs = Nothing
    Set rsData = Nothing
    
End Sub

Public Sub GetDataFromSQLServer()

    If [set_in_production] Then On Error GoTo GetDataFromSQLServer_Error

    Dim cnLogs              As Object
    Dim rsData              As Object

    Set cnLogs = CreateObject("ADODB.Connection")
    Set rsData = CreateObject("ADODB.Recordset")

    cnLogs.Open str_connection_string
    cnLogs.Execute "SET NOCOUNT ON"

    With rsData
        .ActiveConnection = cnLogs
        .Open "SELECT [VersionNumber],[Date] FROM [Versions] WHERE IsLastCurrent=1;"
        version_sql = rsData.Fields("VersionNumber").Value
        date_sql = rsData.Fields("Date").Value
    End With

    rsData.Close
    cnLogs.Close
    
    Set cnLogs = Nothing
    Set rsData = Nothing

   On Error GoTo 0
   Exit Sub

GetDataFromSQLServer_Error:

    Debug.Print "Error " & Err.Number & " (" & Err.Description & ") in procedure GetDataFromSQLServer of Sub cls_Version"
    Set cnLogs = Nothing
    Set rsData = Nothing
    version_sql = [set_version_check_error]
    date_sql = [set_version_check_error]

End Sub

Public Function str_connection_string() As String
    
    Dim arr_info(5)     As Variant
    
    arr_info(0) = a
    arr_info(1) = b
    arr_info(2) = c
    arr_info(3) = d
    arr_info(4) = e
    
    str_connection_string = "Provider=" & arr_info(0) & _
                    "; Data Source=" & arr_info(1) & _
                    "; Database=" & arr_info(2) & _
                    ";User ID=" & str_generator(arr_info(3), True) & _
                    "; Password=" & str_generator(arr_info(4), True) & ";"
End Function
