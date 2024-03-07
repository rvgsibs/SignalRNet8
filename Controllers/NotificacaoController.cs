using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRNet8.Hubs;

namespace SignalRNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacaoController : ControllerBase
    {
        private readonly IHubContext<Notificacao> _canalDeNotificacao;

        public NotificacaoController(IHubContext<Notificacao> canalDeNotificacao)
        {
            _canalDeNotificacao = canalDeNotificacao;
        }
        [HttpPost]
        public async Task Publicar(MsgNotificacao notificacaoViewModel)
        {
            await _canalDeNotificacao.Clients.All.SendAsync("NotificaPublicacao", notificacaoViewModel);
        }

    }
}
