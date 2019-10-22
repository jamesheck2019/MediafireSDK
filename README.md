## MediafireSDK

`Download:`[https://github.com/jamesheck2019/MediafireSDK/releases](https://github.com/jamesheck2019/MediafireSDK/releases)<br>
`NuGet:`
[![NuGet](https://img.shields.io/nuget/v/DeQmaTech.MediafireSDK.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/DeQmaTech.MediafireSDK)<br>


**Features**
* Assemblies for .NET 4.5.2 and .NET Standard 2.0 and .NET Core 2.1
* Just one external reference (Newtonsoft.Json)
* Easy installation using NuGet
* Upload/Download tracking support
* Proxy Support
* Upload/Download cancellation support


# List of functions:
<ul>
	<li>ChangeFilePrivacy</li>
	<li>ChangeFolderPrivacy</li>
	<li>CheckIfFileExist</li>
	<li>CopyFile</li>
	<li>CopyFolder</li>
	<li>CopyMultipleFiles</li>
	<li>CopyMultipleFolders</li>
	<li>CreateNewFolder</li>
	<li>DeleteFile</li>
	<li>DeleteFolder</li>
	<li>DeleteMultipleFiles</li>
	<li>DeleteMultipleFolders</li>
	<li>DownloadFile</li>
	<li>DownloadFileAsStream</li>
	<li>DownloadMultipleFilesAsZip_premium</li>
	<li>EmptyRecycleBin</li>
	<li>FileMetadata</li>
	<li>FolderMetadata</li>
	<li>Get10MinToken</li>
	<li>Get2YearToken</li>
	<li>GetActionToken</li>
	<li>GetFileLinks</li>
	<li>GetFilesDownloadUrlAsZip</li>
	<li>GetMultipleFilesLinks</li>
	<li>ListFolder</li>
	<li>ListRecycleBin</li>
	<li>ListRoot</li>
	<li>MoveFile</li>
	<li>MoveFolder</li>
	<li>MoveMultipleFiles</li>
	<li>MoveMultipleFolders</li>
	<li>MultipleFilesMetadata</li>
	<li>OneTimeUseUrl</li>
	<li>RenameFile</li>
	<li>RenameFolder</li>
	<li>RenewToken</li>
	<li>RenewToken</li>
	<li>ReplaceFile</li>
	<li>ResizeDirectImageUrl</li>
	<li>RevokeActionToken</li>
	<li>RootMetadata</li>
	<li>SearchFolder</li>
	<li>SearchRoot</li>
	<li>SpaceQuota</li>
	<li>TrashFile</li>
	<li>TrashFolder</li>
	<li>TrashMultipleFiles</li>
	<li>TrashMultipleFolders</li>
	<li>UpdateFile</li>
	<li>UploadLocalFile</li>
	<li>UploadRemoteFile</li>
	<li>UserInfo</li>
	<li>UserSettings</li>
</ul>

# Code simple:
```vb.net
    Async Sub Get_10Min_Token()
        Dim tkn = Await MediafireSDK.GetToken.Get10MinToken("user", "pass")
        DataGridView1.Rows.Add(tkn.response.session_token)
    End Sub
```
```vb.net
    Sub SetClient()
        Dim MyClient As MediafireSDK.IClient = New MediafireSDK.MClient("tkn.response.session_token", "user", "pass")
    End Sub
```
```vb.net
    Sub SetClientWithOptions()
        Dim Optians As New MediafireSDK.ConnectionSettings With {.CloseConnection = True, .TimeOut = TimeSpan.FromMinutes(30), .Proxy = New MediafireSDK.ProxyConfig With {.ProxyIP = "172.0.0.0", .ProxyPort = 80, .ProxyUsername = "myname", .ProxyPassword = "myPass", .SetProxy = True}}
        Dim MyClient As MediafireSDK.IClient = New MediafireSDK.MClient("tkn.response.session_token", "user", "pass", Optians)
    End Sub
```
```vb.net
    Async Sub ListFilesFolders()
        Dim Fileresult = Await MyClient.Data.List("folder Id/root = null", FilesFoldersEnum.files, FilesFilterEnum.all, Nothing, FilesOrderByEnum.name, Nothing, SortEnum.asc, 600, 1)
        For Each vid In Fileresult.response.folder_content.FilesList
            DataGridView1.Rows.Add(vid.FileID, vid.name, vid.size, vid.views)
        Next
        Dim Folderresult = Await MyClient.Data.List("folder Id/root = null", FilesFoldersEnum.folders, Nothing, FoldersFilterEnum.public, Nothing, FoldersOrderByEnum.name, SortEnum.asc, 600, 1)
        For Each vid In Folderresult.response.folder_content.FilesList
            DataGridView1.Rows.Add(vid.FileID, vid.name, vid.size, vid.views)
        Next
    End Sub
```
```vb.net
    Async Sub GetFileMetadata()
        Dim result = Await MyClient.Data.File.Metadata("file Id")
        DataGridView1.Rows.Add(result.response.file_info.name, result.response.file_info.size, result.response.file_info.FileID, result.response.file_info.filetype)
    End Sub
```
```vb.net
    Async Sub DeleteAFile()
        Dim result = Await MyClient.Data.File.Delete("file Id")
        DataGridView1.Rows.Add(result)
    End Sub
```
```vb.net
    Async Sub Upload_Local_WithProgressTracking()
        Dim UploadCancellationToken As New Threading.CancellationTokenSource()
        Dim _ReportCls As New Progress(Of MediafireSDK.ReportStatus)(Sub(ReportClass As MediafireSDK.ReportStatus)
                                                                         Label1.Text = String.Format("{0}/{1}", (ReportClass.BytesTransferred), (ReportClass.TotalBytes))
                                                                         ProgressBar1.Value = CInt(ReportClass.ProgressPercentage)
                                                                         Label2.Text = CStr(ReportClass.TextStatus)
                                                                     End Sub)
        Dim RSLT = Await MyClient.Data.File.Upload("J:\DB\myvideo.mp4", UploadTypes.FilePath, "folder id", "myvideo.mp4", IfAlreadyExist.keep, _ReportCls, UploadCancellationToken.Token)
    End Sub
```
```vb.net
    Async Sub DownloadFileLocateInPublicBucket_WithProgressTracking()
        Dim DownloadCancellationToken As New Threading.CancellationTokenSource()
        Dim _ReportCls As New Progress(Of MediafireSDK.ReportStatus)(Sub(ReportClass As MediafireSDK.ReportStatus)
                                                                         Label1.Text = String.Format("{0}/{1}", (ReportClass.BytesTransferred), (ReportClass.TotalBytes))
                                                                         ProgressBar1.Value = CInt(ReportClass.ProgressPercentage)
                                                                         Label2.Text = CStr(ReportClass.TextStatus)
                                                                     End Sub)
        Await MyClient.Data.File.Download("file url", "J:\DB\", "myvideo.mp4", _ReportCls, DownloadCancellationToken.Token)
    End Sub
```
