using System;

namespace Pcs.Web.Models
{
    public class ToastDto
    {
        public ToastDto(ToastType type, string message)
        {
            Type = type;
            Message = message;
        }

        public ToastType Type { get; set; }
        public string Message { get; set; }
        public string TypeString
        {
            get
            {
                return Enum.GetName(Type);
            }
        }
    }

    public enum ToastType
    {
        success,
        error,
        warning
    }
}
