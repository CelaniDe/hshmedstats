using System;

namespace hshmedstats.Web.Models
{
    public class ToastModel
    {
        public ToastModel(ToastType type, string message)
        {
            Type = type;
            Message = message;
        }

        public ToastModel(ToastType type, int? id, string entityName)
        {
            Type = type;
            if (type == ToastType.success)
            {
                Message = $"{entityName} {(id == null ? "added" : "updated")} successfully";
            }
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
