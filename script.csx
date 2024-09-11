public class Script : ScriptBase
{
    public override async Task<HttpResponseMessage> ExecuteAsync()
    {
        // Check if the operation ID matches what is specified in the OpenAPI definition of the connector
        if (this.Context.OperationId == "formatPhoneNumber")
        {
            return await this.HandleFormatPhoneNumberOperation().ConfigureAwait(false);
        }
        if (this.Context.OperationId == "checkEmail")
		{
		    return await this.HandleCheckEmailOperation().ConfigureAwait(false);
		}

        // Handle an invalid operation ID
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
        response.Content = CreateJsonContent($"Unknown operation ID '{this.Context.OperationId}'");
        return response;
    }

    private async Task<HttpResponseMessage> HandleFormatPhoneNumberOperation()
    {
        HttpResponseMessage response;

        // We assume the body of the incoming request looks like this:
        // {
        //   "phoneNumber": "<phone number>"
        // }
        var contentAsString = await this.Context.Request.Content.ReadAsStringAsync().ConfigureAwait(false);

        // Parse as JSON object
        var contentAsJson = JObject.Parse(contentAsString);

        // Get the value of phoneNumber
        var phoneNumber = (string)contentAsJson["Phone Number"];

        // Use RegEx to format the phone number
        var formattedPhoneNumber = FormatPhoneNumber(phoneNumber);

        JObject output = new JObject
        {
            ["originalPhoneNumber"] = phoneNumber,
            ["formattedPhoneNumber"] = formattedPhoneNumber,
        };

        response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = CreateJsonContent(output.ToString());
        return response;
    }

    private string FormatPhoneNumber(string phoneNumber)
    {
        // Remove all non-digit characters
        string digitsOnly = Regex.Replace(phoneNumber, @"\D", "");

        // Ensure we have exactly 10 digits
        if (digitsOnly.Length != 10)
        {
            return "Invalid phone number";
        }

        // Format the phone number
        return $"{digitsOnly.Substring(0, 3)}.{digitsOnly.Substring(3, 3)}.{digitsOnly.Substring(6)}";
    }

    private async Task<HttpResponseMessage> HandleCheckEmailOperation()
    {
        HttpResponseMessage response;

        // We assume the body of the incoming request looks like this:
        // {
        //   "Email": "<email>"
        // }
        var contentAsString = await this.Context.Request.Content.ReadAsStringAsync().ConfigureAwait(false);

        // Parse as JSON object
        var contentAsJson = JObject.Parse(contentAsString);

        // Get the value of phoneNumber
        var email = (string)contentAsJson["Email"];
		    var valid = false;

        // Use RegEx to validate the email
    		Regex regex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
    		Match match = regex.Match(email);
    		if (match.Success)
    			valid = true;

        JObject output = new JObject
        {
            ["inputEmail"] = email,
            ["valid"] = valid,
        };

        response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = CreateJsonContent(output.ToString());
        return response;
    }

}
