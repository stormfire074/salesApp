using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Shared.DependencyServices
{
    public class ToastService
    {
        public event Action<string, string, string> OnShow;

        public void ShowToast(string title, string content, string cssClass = "e-success")
        {
            OnShow?.Invoke(title, content, cssClass);
        }
    }
}
