# RegEx Assistant custom connector for Power Platform

This is simple code-based connector where the method is entirely contained within the custom code block.

This connector has a couple of requests to check/validate input.

<!--
## Installation

There are two ways to install the connector:
-->

## Manual Installation

1. Download [script.csx](https://raw.githubusercontent.com/hobbyman/regex-assistant-custom-connector/main/script.csx) (click on **... > Download** in the top right-hand corner).
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
* <mark>checkEmail</mark>
* <mark>formatPhoneNumber</mark>


### checkEmail Parameters
* Email - string - what it says

#### checkEmail output
The output will be JSON formatted in the following way:
```json
{
  "inputEmail" : "<your-input-email>",
  "valid"      : <boolean>
}
```

### formatPhoneNumber Parameters
* Phone Number - string - what it says

#### formatPhoneNumber output
The output will be JSON formatted in the following way:
```json
{
  "originalPhoneNumber"  : "<your-input-phone-number>",
  "formattedPhoneNumber" : "<formatted-phone-number>"
}
```

## URLs used for my discovery and testing
- **YouTube Video that started this** - [https://stackoverflow.com/a/31524620](https://www.youtube.com/watch?v=9sVl16bwx6w)
    - also, https://stackoverflow.com/a/25919641
- Email RegEx - https://www.tutorialsteacher.com/regex/frequently-used-regex-patterns
- RegEx match - https://stackoverflow.com/a/9853682
- perplexity.ai AI query - https://www.perplexity.ai/search/write-me-c-custom-connector-th-T0FjsokcRpCWBJmEWX8RYQ
