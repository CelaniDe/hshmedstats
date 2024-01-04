using System.Collections.Generic;

namespace Pcs.Web.Models
{
    public class ResultDto
    {
        public ResultDto()
        {
            Errors = new Dictionary<string, List<string>>();
        }

        public ResultDto(bool invalid, Dictionary<string, List<string>> errors, Dictionary<string, string> mappinigs = null)
        {
            Invalid = invalid;
            Errors = errors;

            if (mappinigs != null)
            {
                foreach (var key in mappinigs.Keys)
                {
                    if (Errors.ContainsKey(key))
                    {
                        var values = Errors[key];
                        Errors.Remove(key);
                        Errors.Add(mappinigs[key], values);
                    }
                }
            }
        }

        public bool Invalid { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
    }
}
