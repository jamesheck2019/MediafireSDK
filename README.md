## MediafireSDK

`Download:`[https://github.com/jamesheck2019/MediafireSDK/releases](https://github.com/jamesheck2019/MediafireSDK/releases)<br>
`NuGet:`
[![NuGet](https://img.shields.io/nuget/v/DeQmaTech.MediafireSDK.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/DeQmaTech.MediafireSDK)<br>


# Features:
* Assemblies for .NET 4.5.2 and .NET Standard 2.0 and .NET Core 2.1
* Just one external reference (Newtonsoft.Json)
* Easy installation using NuGet
* Upload/Download tracking support
* Proxy Support
* Upload/Download cancellation support


# List of functions:
**Authentication**
> * Get10MinToken
> * Get2YearToken

**Account**
> * GetActionToken
> * RevokeActionToken
> * UserInfo
> * SpaceQuota
> * UserSettings
> * RenewToken
> * RenewToken

**Files**
> * Copy
> * Delete
> * Metadata
> * Move
> * Trash
> * DownloadAsZip
> * GetDownloadUrlAsZip

**File**
> * Copy
> * Delete
> * Metadata
> * Move
> * Rename
> * ReplaceWith
> * Trash
> * Update
> * Download
> * DownloadLarge
> * DownloadAsStream

**Folders**
> * Copy
> * Delete
> * Move
> * Trash
> * DownloadAsZip
> * GetDownloadUrlAsZip

**Folder**
> * Copy
> * Create
> * Delete
> * Exists
> * ListFiles
> * ListFolders
> * Metadata
> * Move
> * Rename
> * Search
> * Trash
> * GetFileMetadataByFilename
> * GetFolderMetadataByFoldername

**RecycleBin**
> * Empty
> * ListFiles
> * ListFolders

**Root**
> * GetRootID
> * ListFiles
> * ListFolders
> * Search
> * ListPrivateFiles
> * ListPrivateFolders
> * ListPublicFiles
> * ListPublicFolders

**Share**
> * ChangeFilePrivacy
> * ChangeFolderPrivacy
> * GetFileLinks
> * GetFileOneTimeUseUrl
> * GetFilesLinks
> * ListPrivateFiles
> * ListPrivateFolders
> * ListPublicFiles
> * ListPublicFolders

**Data**
> * File
> * Files
> * Folder
> * Folders
> * Root
> * ResizeDirectImageUrl
> * DownloadFile


# CodeMap:
![codemap](https://i.postimg.cc/fLf9xf0d/mf-codemap.png)

# Code simple:
```vb.net
''get session token
Dim tkn = Await MediafireSDK.Authentication.Get10MinToken("user", "pass")

''set client without proxy settings
Dim client As MediafireSDK.IClient = New MediafireSDK.MClient(tkn.response.session_token, "user", "pass", Nothing)
''set client with proxy settings
'Dim client As MediafireSDK.IClient = New MediafireSDK.MClient(tkn.response.session_token, "user", "pass", New MediafireSDK.ConnectionSettings With {.CloseConnection = True, .TimeOut = TimeSpan.FromMinutes(80), .Proxy = New MediafireSDK.ProxyConfig With {.SetProxy = True, .ProxyIP = "127.0.0.1", .ProxyPort = 80, .ProxyUsername = "user", .ProxyPassword = "123456"}})


''Account
Await client.Account.GetActionToken(ActionTypeEnum.upload)
Await client.Account.RenewToken
Await client.Account.RenewToken("session_token")
Await client.Account.RevokeActionToken("action_token")
Await client.Account.SpaceQuota
Await client.Account.UserInfo
Await client.Account.UserSettings

''RecycleBin
Await client.RecycleBin.Empty
Await client.RecycleBin.ListFiles
Await client.RecycleBin.ListFolders

''Share
Await client.Share.ChangeFilePrivacy("file_id", PrivacyEnum.private)
Await client.Share.ChangeFolderPrivacy("folder_id", PrivacyEnum.public)
Await client.Share.GetFileLinks("file_id", LinkTypeEnum.direct_download)
Await client.Share.GetFileOneTimeUseUrl("file_id", True, Nothing)
Await client.Share.GetFilesLinks(New List(Of String) From {{"file_id"}, {"file_id"}}, LinkTypeEnum.direct_download)
Await client.Share.ListPrivateFiles("folder_id")
Await client.Share.ListPrivateFolders("folder_id")
Await client.Share.ListPublicFiles("folder_id")
Await client.Share.ListPublicFolders("folder_id")

Dim CancelToken As New Threading.CancellationTokenSource()
Dim _ReportCls As New Progress(Of MediafireSDK.ReportStatus)(Sub(r) Button1.Text = $"{r.BytesTransferred}/{r.TotalBytes} - {r.ProgressPercentage} <{If(r.TextStatus, "Downloading...")}>")

''File
Await client.Data.File("file_id").Copy("folder_id")
Await client.Data.File("file_id").Delete
Await client.Data.File("file_id").Download("C:\downloads", "rawFile.rar", _ReportCls, CancelToken.Token)
Await client.Data.File("file_id").DownloadAsStream(_ReportCls, CancelToken.Token)
Await client.Data.File("file_id").DownloadLarge("C:\downloads", "rawFile.rar", _ReportCls, CancelToken.Token)
Await client.Data.File("file_id").Metadata
Await client.Data.File("file_id").Move("folder_id")
Await client.Data.File("file_id").Rename("new name")
Await client.Data.File("file_id").ReplaceWith("file_id")
Await client.Data.File("file_id").Trash
Await client.Data.File("file_id").Update("C:\rawFile.rar", UploadTypes.FilePath, "rawFile.rar", _ReportCls, CancelToken.Token)

''Files
Await client.Data.Files(New String() {"file_id1", "file_id2"}).Delete
Await client.Data.Files(New String() {"file_id1", "file_id2"}).Copy("folder_id")
Await client.Data.Files(New String() {"file_id1", "file_id2"}).DownloadAsZip("C:\downloads", "rawFile.rar", _ReportCls, CancelToken.Token)
Await client.Data.Files(New String() {"file_id1", "file_id2"}).GetDownloadUrlAsZip
Await client.Data.Files(New String() {"file_id1", "file_id2"}).Metadata
Await client.Data.Files(New String() {"file_id1", "file_id2"}).Move("folder_id")
Await client.Data.Files(New String() {"file_id1", "file_id2"}).Trash

''Folder
Await client.Data.Folder("folder_id").Copy("folder_id")
Await client.Data.Folder("folder_id").Create("folder name", False)
Await client.Data.Folder("folder_id").Delete
Await client.Data.Folder("folder_id").Exists("folder_name")
Await client.Data.Folder("folder_id").GetFileMetadataByFilename("file_name", False)
Await client.Data.Folder("folder_id").GetFolderMetadataByFoldername("folder_name", False)
Await client.Data.Folder("folder_id").ListFiles
Await client.Data.Folder("folder_id").ListFolders
Await client.Data.Folder("folder_id").Metadata
Await client.Data.Folder("folder_id").Move("folder_id")
Await client.Data.Folder("folder_id").Rename("folder name")
Await client.Data.Folder("folder_id").Search("emy")
Await client.Data.Folder("folder_id").Trash

''Folders
Await client.Data.Folders(New String() {"folder_id1", "folder_id2"}).Delete
Await client.Data.Folders(New String() {"folder_id1", "folder_id2"}).Copy("folder_id")
Await client.Data.Folders(New String() {"folder_id1", "folder_id2"}).DownloadAsZip("C:\downloads", "rawFile.rar", _ReportCls, CancelToken.Token)
Await client.Data.Folders(New String() {"folder_id1", "folder_id2"}).GetDownloadUrlAsZip
Await client.Data.Folders(New String() {"folder_id1", "folder_id2"}).Move("folder_id")
Await client.Data.Folders(New String() {"folder_id1", "folder_id2"}).Trash

''Root
Await client.Data.Root.ListFiles
Await client.Data.Root.ListFolders
Await client.Data.Root.ListPrivateFiles
Await client.Data.Root.ListPrivateFolders
Await client.Data.Root.ListPublicFiles
Await client.Data.Root.ListPublicFolders
Await client.Data.Root.Search("emy")


Dim link = (Await client.Share.GetFileLinks("file_id", LinkTypeEnum.direct_download)).response.links(0).direct_download
Await client.Data.DownloadFile(link, "C:\downloads", "rawFile.rar", _ReportCls, CancelToken.Token)
Dim imgLink = (Await client.Data.File("file_id").Metadata).response.file_info.ImgUrl
client.Data.ResizeDirectImageUrl(imgLink, ImageResizeEnum._107x80)

```
