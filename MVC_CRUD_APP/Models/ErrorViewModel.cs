namespace MVC_CRUD_APP.Models
{
    public class ErrorViewModel // This class represents the model for error handling in the MVC application.
    {
        public string? RequestId { get; set; } // This property holds the unique identifier for the request, which can be useful for debugging.

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); // This property checks if the RequestId is not null or empty, indicating whether to display the RequestId in the view.
    }
}
