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
        private IProcessManager _processManager;

        public ProcessHub(IProcessManager processManager)
        {
            _processManager = processManager;
        }

        public void GetStatus()
        {
            //var _ProcessManager = ProcessManager.Instance;
            int _status = _processManager.Status;
            string _statusLetra=string.Empty;
            _statusLetra=(_status==0)?"En espera":"Trabajando";
            if (this.Context != null)
                Clients.All.update(_statusLetra);
        }





    }
}