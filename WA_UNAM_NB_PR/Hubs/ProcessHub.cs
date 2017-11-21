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

        public async Task StartProcess()
        {
            await _processManager.Go();
        }

        public void StopProcess()
        {
            _processManager.Stop();
        }

        public void GetStatus()
        {  
            string statusLetra=string.Empty;
            statusLetra=(_processManager.Status==0)?"En espera":"Trabajando";
            if (this.Context != null)
                Clients.All.update(statusLetra);
        }





    }
}