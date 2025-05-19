using Microsoft.AspNetCore.Authorization;
using WhiteNoise.Domain.Interfaces.Repositories;

namespace WhiteNoise.Controllers
{
    [Authorize]
    public class ProfissionalController : BaseController
    {
        #region Private Fields
        private readonly IProfissionalRepository _profissionalRepository;

        #endregion

        public ProfissionalController()
        {
            
        }

    }
}
