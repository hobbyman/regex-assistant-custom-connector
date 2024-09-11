# Zip File custom connector for Power Platform

This is simple code-based connector where the method is entirely contained within the custom code block.

Purpose of the connector is to take is zip file manipulations from Power Automate.

<!--
## Installation

There are two ways to install the connector:
-->

## Manual Installation

1. Download [script.csx](https://raw.githubusercontent.com/hobbyman/zip-file-connector/master/script.csx) (click on **... > Download** in the top right-hand corner).
2. Sign in to [https://make.powerapps.com](https://make.powerapps.com).
3. Select target environment.
4. Select **Custom connectors** in the left navigation.
5. Select **+ New customer connector > Import an OpenAPI from URL**.
   * Enter **CSV Magic** as Connector name.
   * Copy and paste this URL: `https://raw.githubusercontent.com/hobbyman/zip-file-connector/master/apiDefinition.json`
6. Select **Import** then select **Continue**.
7. Select **Code** in the navigation dropdown.
8. Flip the switch to **Code Enabled**.
9. Select **Upload** and upload **script.csx** saved earlier.
10. Select **CsvToJson** in the list of operations.
11. Select **Create connector**.

<!--
### Power Platform CLI (recommended)

What do you need?

* Audacity to use command line
* [Microsoft Power Platform CLI](https://learn.microsoft.com/power-platform/developer/cli/introduction)

#### Steps

1. Create auth profile if you don't have one already and make it active.

   ```shell
   pac auth create -n Code -u https://yoururl.crmN.dynamics.com
   pac auth select -n Code
   ```

1. Upload custom connector

   ```shell
   pac connector create --settings-file settings.json
   ```

-->


## Methods
* <mark>CreateZip</mark>
* <mark>ExtractZip</mark> (not yet implemented)



### CreateZip Parameters

* File Array - string - example below
```
[
    {
        "filename" : "blah.txt",
        "content"  : "base64-encoding-of-the-file"
    },
    {
        "filename" : "whatever.jpg",
        "content"  : "base64-encoding-of-the-file"
    }
]
```
* Zip File Name - string - what it says

#### Getting the base64 encoding of a file in Sharepoint
Go to this [nice article](https://manueltgomes.com/reference/power-automate-action-reference/sharepoint-get-file-content-action/) for start. Basically, you need to get the output of **Get file content** into a variable or compose. BUT, pay attention, you need to get the **$content**; that's what will need to go into the **content** property in the **File Array**



## URLs used for my discovery and testing
- MemoryStream from Base64 - https://stackoverflow.com/a/31524620
    - also, https://stackoverflow.com/a/25919641
- JObject/JPropery - https://www.codeproject.com/Questions/5257437/Dynamically-keep-adding-jarray-value-to-jobject
- **This one is the main idea for createZipNew() and createZipFromArray()** - https://learn.microsoft.com/en-us/answers/questions/741047/zip-file-created-directly-from-memorystream-is-emp
- idea for passing in an array via the Swagger definition - https://stackoverflow.com/a/54443363
- Swagger Editor Next - https://editor-next.swagger.io/
- Swagger Editor - https://editor.swagger.io/
- Encode FileStream to Base64 (not sure this is needed) - https://stackoverflow.com/a/46223990
- **Iterate over a JArray** - https://stackoverflow.com/a/41810862
- **Custom Connector from Code** - https://learn.microsoft.com/en-us/connectors/custom-connectors/write-code
- **THE Code example I need for returning a Zip file ** - https://github.com/microsoft/PowerPlatformConnectors/blob/b051dd9e1bd7cef1a140de0983c4c6a244dc7d39/custom-connectors/CopilotForFinanceCommunications/script.csx#L376
- Convert JSON String to JArray - https://www.codeproject.com/Questions/1140760/How-to-convert-to-json-string-to-json-array
- Simple create Zip File with one file - https://stackoverflow.com/a/43120552
- **In Memory Zip Files** - https://code-maze.com/csharp-create-a-zip-file-in-memory/
- **Where this whole idea started** - https://tachytelic.net/2024/06/create-zip-file-power-automate/
