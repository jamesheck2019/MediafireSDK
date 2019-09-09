# MediafireSDK
Mediafire SDK for .NET 4.5.2


`Download`
[https://github.com/jamesheck2019/MediafireSDK/releases](https://github.com/jamesheck2019/MediafireSDK/releases)<br>

[![NuGet version (BlackBeltCoder.Silk)](https://img.shields.io/nuget/v/DeQmaTech.MediafireSDK.svg?style=plastic)](https://www.nuget.org/packages/DeQmaTech.MediafireSDK/)

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
**get 10 min token**
```vb
Dim tkn = Await MediafireSDK.GetToken.Get10MinToken("user", "pass")
```
**set client**
```vb
Dim Clnt As MediafireSDK.IClient = New MediafireSDK.MClient("token", "user", "pass")
```
**list root files/folders**
```vb
Dim RSLT = Await Clnt.ListRoot(fileOrFolder, Nothing, FoldersFilterEnum.public, Nothing, FoldersOrderByEnum.name, SortEnum.asc, 500, 1)
For Each onz In RSLT.response.folder_content.FoldersList
   DataGridView1.Rows.Add(onz.name, onz.FolderID, onz.total_files, onz.total_folders, onz.total_size, onz.folder_count, onz.file_count)
Next
For Each onz In RSLT.response.folder_content.FilesList
   DataGridView1.Rows.Add(onz.name, onz.FileID, ISisFunctions.Bytes_To_KbMbGb.SetBytes(onz.size), onz.filetype, onz.mimetype, onz.ImgUrl, onz.links.normal_download)
Next
```
**upload local file (without progress tracking)**
```vb.net
Dim UploadCancellationToken As New Threading.CancellationTokenSource()
Dim RSLT = Clnt.UploadLocalFile("C:\ureWiz.png", UploadTypes.FilePath, "DestinationFolderID", "ureWiz.png", IfAlreadyExist.keep, nothing, UploadCancellationToken.Token)
```
**upload local file with progress tracking**
```vb.net
Dim UploadCancellationToken As New Threading.CancellationTokenSource()
Dim prog_ReportCls As New Progress(Of MediafireSDK.ReportStatus)(Sub(ReportClass As MediafireSDK.ReportStatus)
                   Label1.Text = String.Format("{0}/{1}", (ReportClass.BytesTransferred), (ReportClass.TotalBytes))
                   ProgressBar1.Value = CInt(ReportClass.ProgressPercentage)
                   Label2.Text = CStr(ReportClass.TextStatus)
                   End Sub)
Dim RSLT = Clnt.UploadLocalFile("C:\ureWiz.png", UploadTypes.FilePath, "DestinationFolderID", "ureWiz.png", IfAlreadyExist.keep, prog_ReportCls , UploadCancellationToken.Token)
```
