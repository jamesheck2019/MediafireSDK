# MediafireSDK
`Download`
[https://github.com/jamesheck2019/MediafireSDK/releases](https://github.com/jamesheck2019/MediafireSDK/releases)<br>
Mediafire SDK for .NET
<ul>
	<li>.NET 4.5.2</li>
	<li>One dependency library [Newtonsoft.Json]</li>
</ul>
=========
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


# List of functions:
```csharp
public interface IClient
	{
		Task<JSON_GetActionToken> GetActionToken(FMutilities.ActionTypeEnum ActionType);

		Task<JSON_RevokeActionToken> RevokeActionToken(string ActionToken);

		Task<JSON_UserInfo> UserInfo();

		Task<JSON_SpaceQuota> SpaceQuota();

		Task<JSON_UserSettings> UserSettings();

		Task<JSON_RenewToken> RenewToken();

		Task<JSON_RenewToken> RenewToken(string SessionToken);

		Task<JSON_UploadRemoteFile> UploadRemoteFile(string UrlToUP, string DestinationFolderID, string Filename = null);

		Task<bool> CheckIfFileExist(string DestinationFolderID, string Filename);

		Task<JSON_UploadLocalFile> UploadLocalFile(object FileToUP, MClient.UploadTypes TheUpType, string DestinationFolderID, string Filename = null, MClient.IfAlreadyExist WhatIfFileAlreadyExists = MClient.IfAlreadyExist.keep, IProgress<ReportStatus> ReportCls = null, ProxyConfig _proxi = null, CancellationToken token = default(CancellationToken));

		Task<JSON_ListFolder> ListRoot(FMutilities.FilesFoldersEnum GetFilesorFolders, FMutilities.FilesFilterEnum? FilesFilter = null, FMutilities.FoldersFilterEnum? FoldersFilter = null, FMutilities.FilesOrderByEnum? FilesOrderBy = null, FMutilities.FoldersOrderByEnum? FoldersOrderBy = null, FMutilities.SortEnum? Sort = null, int Limit = 1000, int Offset = 1);

		Task<JSON_ListFolder> ListFolder(string FolderID, FMutilities.FilesFoldersEnum GetFilesorFolders, FMutilities.FilesFilterEnum? FilesFilter = null, FMutilities.FoldersFilterEnum? FoldersFilter = null, FMutilities.FilesOrderByEnum? FilesOrderBy = null, FMutilities.FoldersOrderByEnum? FoldersOrderBy = null, FMutilities.SortEnum? Sort = null, int Limit = 1000, int Offset = 1);

		Task<JSON_SearchRoot> SearchRoot(string SearchKeyword, FMutilities.FilesFilterEnum? Filter = null, FMutilities.SortEnum? Sort = null, int Limit = 1000, int Offset = 1);

		Task<JSON_SearchRoot> SearchFolder(string FolderID, string SearchKeyword, FMutilities.FilesFilterEnum? Filter = null, bool IncludeTrash = false, FMutilities.SortEnum? Sort = null, int Limit = 1000, int Offset = 1);

		Task<JSON_GetFolderMetadata> FolderMetadata(string FolderID);

		Task<JSON_GetFolderMetadata> RootMetadata();

		Task<JSON_CreateNewFolder> CreateNewFolder(string DestinationFolderID, string FolderName, bool AutoRename);

		Task<JSON_CopyFolder> CopyFolder(string SourceFolderID, string DestinationFolderID);

		Task<JSON_CopyFolder> CopyMultipleFolders(List<string> SourceFoldersIDs, string DestinationFolderID);

		Task<JSON_MoveFolder> MoveFolder(string SourceFolderID, string DestinationFolderID);

		Task<JSON_MoveFolder> MoveMultipleFolders(List<string> SourceFoldersIDs, string DestinationFolderID);

		Task<JSON_MoveFolder> DeleteFolder(string DestinationFoldersID);

		Task<JSON_MoveFolder> DeleteMultipleFolders(List<string> DestinationFoldersIDs);

		Task<JSON_CopyFolder> TrashFolder(string DestinationFolderID);

		Task<JSON_CopyFolder> TrashMultipleFolders(List<string> DestinationFoldersIDs);

		Task<JSON_MoveFolder> RenameFolder(string DestinationFolderID, string RenameTo);

		Task<JSON_MoveFolder> ChangeFolderPrivacy(string DestinationFolderID, FMutilities.PrivacyEnum Privacy);

		Task<JSON_CopyFile> CopyFile(string SourceFileID, string DestinationFolderID);

		Task<JSON_CopyFile> CopyMultipleFiles(List<string> SourceFilesIDs, string DestinationFolderID);

		Task<JSON_NoResponse> MoveFile(string SourceFileID, string DestinationFolderID);

		Task<JSON_NoResponse> MoveMultipleFiles(List<string> SourceFilesIDs, string DestinationFolderID);

		Task<JSON_NoResponse> TrashFile(string DestinationFileID);

		Task<JSON_NoResponse> TrashMultipleFiles(List<string> DestinationFilesIDs);

		Task<JSON_NoResponse> DeleteFile(string DestinationFileID);

		Task<JSON_NoResponse> DeleteMultipleFiles(List<string> DestinationFilesIDs);

		Task DownloadMultipleFilesAsZip_premium(List<string> FilesFoldersIDs, string FileSaveDir, string FileName, IProgress<ReportStatus> ReportCls = null, ProxyConfig _proxi = null, int TimeOut = 60, CancellationToken token = default(CancellationToken));

		Task<JSON_NoResponse> GetFilesDownloadUrlAsZip(List<string> FilesFoldersIDs);

		Task<JSON_GetFileMetadata> FileMetadata(string FileID);

		Task<JSON_GetFileMetadata> MultipleFilesMetadata(List<string> SourceFilesIDs);

		Task<JSON_GetFileLinks> GetFileLinks(string FileID, FMutilities.LinkTypeEnum? LinkToGet = null);

		Task<JSON_GetFileMetadata> OneTimeUseUrl(string FileID, bool? DestroyAfterUse = null, string UrlValidFor_InMin = null);

		Task<JSON_NoResponse> ReplaceFile(string SourceFileID, string DestinationFolderID);

		Task<JSON_MoveFolder> RenameFile(string DestinationFileID, string RenameTo);

		Task<JSON_MoveFolder> ChangeFilePrivacy(string DestinationFileID, FMutilities.PrivacyEnum Privacy);

		string ResizeDirectImageUrl(string DirectImageUrl, FMutilities.ImageResizeEnum ImageResize);

		Task DownloadFile(string FileUrl, string FileSaveDir, string FileName, IProgress<ReportStatus> ReportCls = null, ProxyConfig _proxi = null, int TimeOut = 60, CancellationToken token = default(CancellationToken));

		Task<Stream> DownloadFileAsStream(string FileUrl, IProgress<ReportStatus> ReportCls = null, ProxyConfig _proxi = null, int TimeOut = 60, CancellationToken token = default(CancellationToken));

		Task<JSON_GetFileLinks> GetMultipleFilesLinks(List<string> DestinationFilesIDs, FMutilities.LinkTypeEnum? LinkToGet = null);

		Task<JSON_ListRecycleBin> ListRecycleBin(FMutilities.FilesFoldersEnum GetFilesorFolders, bool GetCountersOnly = false, int Offset = 1);

		Task<JSON_NoResponse> EmptyRecycleBin();

		Task<JSON_ListFolder> ListAllPrivateFilesFolders(FMutilities.FilesFoldersEnum GetFilesorFolders, string FolderID = null, FMutilities.FilesOrderByEnum? OrderBy = null, FMutilities.SortEnum? Sort = null, int Limit = 1000, int Offset = 1);

		Task<JSON_ListFolder> ListAllPublicFilesFolders(FMutilities.FilesFoldersEnum GetFilesorFolders, string FolderID = null, FMutilities.FilesOrderByEnum? OrderBy = null, FMutilities.SortEnum? Sort = null, int Limit = 1000, int Offset = 1);

		Task<bool> CheckIfFolderExist(string DestinationFolderID, string Foldername);

		Task<JSON_GetFileMetadataByFilename> GetFileMetadataByFilename(string DestinationFolderID, string Filename, bool Recursive);

		Task<JSON_GetFolderMetadataByFoldername> GetFolderMetadataByFoldername(string DestinationFolderID, string Foldername, bool Recursive);

		Task<JSON_UploadLocalFile> UpdateFile(object FileToUP, MClient.UploadTypes TheUpType, string DestinationFileID, string Filename = null, IProgress<ReportStatus> ReportCls = null, ProxyConfig _proxi = null, CancellationToken token = default(CancellationToken));
	}
```

# Code simple:
```vb
Dim Clnt As MediafireSDK.IClient = New MediafireSDK.MClient("", "xxxxxxxxxxxx", "xxxxxxxxxxx")
        Dim RSLT = Await Clnt.ListRoot(CB_fileOrFolder.SelectedIndex, Nothing, MediafireSDK.FMutilities.FoldersFilterEnum.public, Nothing, MediafireSDK.FMutilities.FoldersOrderByEnum.name, MediafireSDK.FMutilities.SortEnum.asc, 500, 1)

        If CB_fileOrFolder.SelectedIndex = MediafireSDK.FMutilities.FilesFoldersEnum.folders Then
            For Each onz In RSLT.response.folder_content.FoldersList
                DataGridView1.Rows.Add(onz.name, onz.FolderID, onz.total_files, onz.total_folders, onz.total_size, onz.folder_count, onz.file_count)
            Next
        Else
            For Each onz In RSLT.response.folder_content.FilesList
                DataGridView1.Rows.Add(onz.name, onz.FileID, ISisFunctions.Bytes_To_KbMbGb.SetBytes(onz.size), onz.filetype, onz.mimetype, onz.ImgUrl, onz.links.normal_download)
            Next
        End If
```
