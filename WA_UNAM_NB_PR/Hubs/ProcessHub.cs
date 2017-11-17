using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using WA_UNAM_NB_PR.Controllers.Services;

namespace WA_UNAM_NB_PR.Hubs
{
    public class ProcessHub : Hub
    {
        public override Task OnDisconnected(bool stopCalled)
        {
            string cadena = "Te desconectaste del servidor";
            Clients.All.update(cadena);
            return base.OnDisconnected(stopCalled);
        }
        public void GetStatus()
        {
            var _ProcessManager = ProcessManager.Instance;
            int _status = _ProcessManager.Status;
            string _statusLetra=string.Empty;
            _statusLetra=(_status==0)?"En espera":"Trabajando";
            if (this.Context != null)
                Clients.All.update(_statusLetra);
        }





    }
}