# NETLIcense.IO exemple-project

(You can watch the video presentation [here](https://vimeo.com/329132548) )

NETLicense.IO is a rock-solid licensing system for your .NET Framework projects.

As you can see on the video, it has never been that easy to protect your project.

# Tutorial

## 1] Mark servser side variables

First, you need to **mark sensitive strings** (decryption / encryption key, secret string etc.)

To do that, you use the ObfuscationAttribute as following : 
```csharp
[Obfuscation(Exclude = false, Feature = "server")]
```
![](https://i.imgur.com/PWsN7Ko.png)

(See code exemple [here](https://github.com/XenocodeRCE/exemple-project/blob/cde3499d23c500654dead7f55798332a6de7a5f6/NETLicense.IO%20exemple/Form1.cs#L14-L15) )

## 2] Mark remote methods

Finally, you need to **mark sensitive function(s)** (decryption / encryption, MySQL DB connection, anything you don't want anyone to see)

To do that, you use the ObfuscationAttribute as following : 
```csharp
[Obfuscation(Exclude = false, Feature = "remote")]
```
![](https://i.imgur.com/QDsdlvS.png)

(See code exemple [here](https://github.com/XenocodeRCE/exemple-project/blob/cde3499d23c500654dead7f55798332a6de7a5f6/NETLicense.IO%20exemple/Form1.cs#L48-L57) )
