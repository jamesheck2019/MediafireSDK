Imports MediafireSDK.JSON

Public Interface IClient


    Function GetActionToken(ActionType As FMutilities.ActionTypeEnum) As Task(Of JSON_GetActionToken)
    Function RevokeActionToken(ActionToken As String) As Task(Of JSON_RevokeActionToken)
    Function UserInfo() As Task(Of JSON_UserInfo)
    Function SpaceQuota() As Task(Of JSON_SpaceQuota)
    Function UserSettings() As Task(Of JSON_UserSettings)
    Function RenewToken() As Task(Of JSON_RenewToken)
    Function RenewToken(SessionToken As String) As Task(Of JSON_RenewToken)


    Function UploadRemoteFile(UrlToUP As String, DestinationFolderID As String, Optional Filename As String = Nothing) As Task(Of JSON_UploadRemoteFile)
    Function CheckIfFileExist(DestinationFolderID As String, Filename As String, Optional Size As String = Nothing) As Task(Of JSON_CheckIfFileExist)
    Function UploadLocalFile(FileToUP As Object, TheUpType As MClient.UploadTypes, DestinationFolderID As String, Optional Filename As String = Nothing, Optional WhatIfFileAlreadyExists As MClient.IfAlreadyExist = MClient.IfAlreadyExist.keep, Optional ReportCls As IProgress(Of ReportStatus) = Nothing, Optional _proxi As ProxyConfig = Nothing, Optional token As Threading.CancellationToken = Nothing) As Task(Of JSON_UploadLocalFile)
    Function UpdateFile(FileToUP As Object, TheUpType As MClient.UploadTypes, DestinationFileID As String, Optional NewFilename As String = Nothing, Optional ReportCls As IProgress(Of ReportStatus) = Nothing, Optional _proxi As ProxyConfig = Nothing, Optional token As Threading.CancellationToken = Nothing) As Task(Of JSON_UploadLocalFile)
    Function ListRoot(GetFilesorFolders As FMutilities.FilesFoldersEnum, Optional FilesFilter As FMutilities.FilesFilterEnum? = Nothing, Optional FoldersFilter As FMutilities.FoldersFilterEnum? = Nothing, Optional FilesOrderBy As FMutilities.FilesOrderByEnum? = Nothing, Optional FoldersOrderBy As FMutilities.FoldersOrderByEnum? = Nothing, Optional Sort As FMutilities.SortEnum? = Nothing, Optional Limit As Integer = 1000, Optional Offset As Integer = 1) As Task(Of JSON_ListFolder)
    Function ListFolder(FolderID As String, GetFilesorFolders As FMutilities.FilesFoldersEnum, Optional FilesFilter As FMutilities.FilesFilterEnum? = Nothing, Optional FoldersFilter As FMutilities.FoldersFilterEnum? = Nothing, Optional FilesOrderBy As FMutilities.FilesOrderByEnum? = Nothing, Optional FoldersOrderBy As FMutilities.FoldersOrderByEnum? = Nothing, Optional Sort As FMutilities.SortEnum? = Nothing, Optional Limit As Integer = 1000, Optional Offset As Integer = 1) As Task(Of JSON_ListFolder)


    Function SearchRoot(SearchKeyword As String, Optional Filter As FMutilities.FilesFilterEnum? = Nothing, Optional Sort As FMutilities.SortEnum? = Nothing, Optional Limit As Integer = 1000, Optional Offset As Integer = 1) As Task(Of JSON_SearchRoot)
    Function SearchFolder(FolderID As String, SearchKeyword As String, Optional Filter As FMutilities.FilesFilterEnum? = Nothing, Optional IncludeTrash As Boolean = False, Optional Sort As FMutilities.SortEnum? = Nothing, Optional Limit As Integer = 1000, Optional Offset As Integer = 1) As Task(Of JSON_SearchRoot)

    Function FolderMetadata(FolderID As String) As Task(Of JSON_GetFolderMetadata)
    Function RootMetadata() As Task(Of JSON_GetFolderMetadata)
    Function CreateNewFolder(DestinationFolderID As String, FolderName As String, AutoRename As Boolean) As Task(Of JSON_CreateNewFolder)

    Function CopyFolder(SourceFolderID As String, DestinationFolderID As String) As Task(Of JSON_CopyFolder)
    Function CopyMultipleFolders(SourceFoldersIDs As List(Of String), DestinationFolderID As String) As Task(Of JSON_CopyFolder)

    Function MoveFolder(SourceFolderID As String, DestinationFolderID As String) As Task(Of JSON_MoveFolder)
    Function MoveMultipleFolders(SourceFoldersIDs As List(Of String), DestinationFolderID As String) As Task(Of JSON_MoveFolder)

    Function DeleteFolder(DestinationFoldersID As String) As Task(Of JSON_MoveFolder)
    Function DeleteMultipleFolders(DestinationFoldersIDs As List(Of String)) As Task(Of JSON_MoveFolder)
    Function TrashFolder(DestinationFolderID As String) As Task(Of JSON_CopyFolder)
    Function TrashMultipleFolders(DestinationFoldersIDs As List(Of String)) As Task(Of JSON_CopyFolder)


    Function RenameFolder(DestinationFolderID As String, RenameTo As String) As Task(Of JSON_MoveFolder)
    Function ChangeFolderPrivacy(DestinationFolderID As String, Privacy As FMutilities.PrivacyEnum) As Task(Of JSON_MoveFolder)

    Function CopyFile(SourceFileID As String, DestinationFolderID As String) As Task(Of JSON_CopyFile)
    Function CopyMultipleFiles(SourceFilesIDs As List(Of String), DestinationFolderID As String) As Task(Of JSON_CopyFile)

    Function MoveFile(SourceFileID As String, DestinationFolderID As String) As Task(Of JSON_NoResponse)
    Function MoveMultipleFiles(SourceFilesIDs As List(Of String), DestinationFolderID As String) As Task(Of JSON_NoResponse)

    Function TrashFile(DestinationFileID As String) As Task(Of JSON_NoResponse)
    Function TrashMultipleFiles(DestinationFilesIDs As List(Of String)) As Task(Of JSON_NoResponse)

    Function DeleteFile(DestinationFileID As String) As Task(Of JSON_NoResponse)
    Function DeleteMultipleFiles(DestinationFilesIDs As List(Of String)) As Task(Of JSON_NoResponse)

    Function DownloadMultipleFilesAsZip_premium(FilesFoldersIDs As List(Of String), FileSaveDir As String, FileName As String, Optional ReportCls As IProgress(Of ReportStatus) = Nothing, Optional _proxi As ProxyConfig = Nothing, Optional TimeOut As Integer = 60, Optional token As Threading.CancellationToken = Nothing) As Task
    Function GetFilesDownloadUrlAsZip(FilesFoldersIDs As List(Of String)) As Task(Of JSON_NoResponse)

    Function FileMetadata(FileID As String) As Task(Of JSON_GetFileMetadata)
    Function MultipleFilesMetadata(SourceFilesIDs As List(Of String)) As Task(Of JSON_GetFileMetadata)

    Function GetFileLinks(FileID As String, Optional LinkToGet As FMutilities.LinkTypeEnum? = Nothing) As Task(Of JSON_GetFileLinks)
    Function OneTimeUseUrl(FileID As String, Optional DestroyAfterUse As Boolean? = Nothing, Optional UrlValidFor_InMin As String = Nothing) As Task(Of JSON_GetFileMetadata)
    Function ReplaceFile(SourceFileID As String, DestinationFolderID As String) As Task(Of JSON_NoResponse)

    Function RenameFile(DestinationFileID As String, RenameTo As String) As Task(Of JSON_MoveFolder)
    Function ChangeFilePrivacy(DestinationFileID As String, Privacy As FMutilities.PrivacyEnum) As Task(Of JSON_MoveFolder)
    Function ResizeDirectImageUrl(DirectImageUrl As String, ImageResize As FMutilities.ImageResizeEnum) As String

    Function DownloadFile(FileUrl As String, FileSaveDir As String, FileName As String, Optional ReportCls As IProgress(Of ReportStatus) = Nothing, Optional _proxi As ProxyConfig = Nothing, Optional TimeOut As Integer = 60, Optional token As Threading.CancellationToken = Nothing) As Task
    Function DownloadFileAsStream(FileUrl As String, Optional ReportCls As IProgress(Of ReportStatus) = Nothing, Optional _proxi As ProxyConfig = Nothing, Optional TimeOut As Integer = 60, Optional token As Threading.CancellationToken = Nothing) As Task(Of IO.Stream)
    Function GetMultipleFilesLinks(DestinationFilesIDs As List(Of String), Optional LinkToGet As FMutilities.LinkTypeEnum? = Nothing) As Task(Of JSON_GetFileLinks)
    Function ListRecycleBin(GetFilesorFolders As FMutilities.FilesFoldersEnum, Optional GetCountersOnly As Boolean = False, Optional Offset As Integer = 1) As Task(Of JSON_ListRecycleBin)
    Function EmptyRecycleBin() As Task(Of JSON_NoResponse)


End Interface
