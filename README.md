# OpenSSHFileTransfer
c# project to send file using open SSH
WHAT IS SFTP?
SFTP stands for SSH File Transfer Protocol or Secure File Transfer Protocol. It is a protocol used to transfer files between remote machines over a secure shell.
In almost all cases, SFTP is preferable over FTP because of security features. FTP is not a secure protocol & it should only be used on a trusted network.
CHOOSING LIBRARY FOR C#
A lot of search & after testing many libraries I finally met with SSH.NET which was working perfectly with .Net project & the good thing was that It does its job in a very few lines of Code.
So we’ll use SSH.NET
WHAT IS SSH.NET?
SSH.NET is an open-source library available at Nuget for .NET to work over SFTP. It is also optimized for parallelism to achieve the best possible performance. It was inspired by Sharp.SSH library which was ported from Java. This library is a complete rewrite using .Net, without any third party dependencies.


