using Microsoft.AspNetCore.Mvc;

namespace jwtokencore.Web.Api.Presenters
{
  public sealed class JsonContentResult : ContentResult
  {
    public JsonContentResult()
    {
      ContentType = "application/json";
    }
  }
}
