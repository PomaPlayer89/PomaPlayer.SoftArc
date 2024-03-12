using Microsoft.AspNetCore.Mvc;
using PomaPlayer.SoftArc.Logic.DtoModels.Filters;
using PomaPlayer.SoftArc.Web.Features.DtoModels.Center;
using PomaPlayer.SoftArc.Web.Features.DtoModels.Customer;
using PomaPlayer.SoftArc.Web.Features.DtoModels.Trainer;
using PomaPlayer.SoftArc.Web.Features.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PomaPlayer.SoftArc.Web.Controllers
{
    [Route("[controller]")]
    public class ManageController : BaseController
    {
        // todo: лучше разбить на три контроллера, каждый из которых будет подтягивать свой manager, НО для упрощения и так сойдет
        private readonly ICenterManager _centerManager;
        private readonly ITrainerManager _trainerManager;
        private readonly ICustomerManager _customerManager;

        public const string Manage = "Manage";

        public ManageController(
            ICenterManager centerManager,
            ITrainerManager trainerManager,
            ICustomerManager customerManager)
        {
            _centerManager = centerManager;
            _trainerManager = trainerManager;
            _customerManager = customerManager;
        }

        #region Center

        [HttpGet(nameof(GetListCenters), Name = nameof(GetListCenters))]
        public async Task<ActionResult<CenterDto[]>> GetListCenters()
        {
            var list = await _centerManager.GetListCentersAsync(new CenterFilter());

            return View(list);
        }

        [HttpGet(nameof(GetInfoCenter), Name = nameof(GetInfoCenter))]
        public async Task<ActionResult<InfoCenterDto>> GetInfoCenter([FromQuery, Required] Guid isnCenter)
        {
            var model = await _centerManager.GetInfoCenterAsync(isnCenter);
            return View(model);
        }

        [HttpGet(nameof(Center), Name = nameof(Center))]
        public ActionResult Center()
        {
            return View(new EditCenterDto());
        }

        [HttpGet(nameof(GetEditCenter), Name = nameof(GetEditCenter))]
        public async Task<ActionResult<EditCenterDto>> GetEditCenter([FromQuery, Required] Guid isnCenter)
        {
            var model = await _centerManager.GetCenterAsync(isnCenter);

            return View(nameof(Center), model);
        }

        [HttpPost(nameof(CreateCenter), Name = nameof(CreateCenter))]
        public async Task<ActionResult> CreateCenter([FromForm] EditCenterDto model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(nameof(Center), model);

            await _centerManager.CreateCenterAsync(model, cancellationToken);

            return RedirectToAction(nameof(GetListCenters));
        }

        [HttpPost(nameof(UpdateCenter), Name = nameof(UpdateCenter))]
        public async Task<ActionResult> UpdateCenter([FromForm] EditCenterDto model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(nameof(Center), model);

            await _centerManager.UpdateCenterAsync(model, cancellationToken);

            return RedirectToAction(nameof(GetListCenters));
        }

        [HttpGet(nameof(DeleteCenter), Name = nameof(DeleteCenter))]
        public async Task<ActionResult> DeleteCenter([FromQuery, Required] Guid isnCenter, CancellationToken cancellationToken)
        {
            await _centerManager.DeleteCenterAsync(isnCenter, cancellationToken);

            return RedirectToAction(nameof(GetListCenters));
        }

        [HttpPost(nameof(SetBindWithTrainer), Name = nameof(SetBindWithTrainer))]
        public async Task<ActionResult> SetBindWithTrainer([FromBody] SetBindWithTrainerDto model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return Json(ModelState);

            await _centerManager.SetBindWithTrainerAsync(model, cancellationToken);

            return Ok();
        }

        // todo: лучше переделать post и передавать данные через ajax, НО для упрощения сделано через get
        [HttpGet(nameof(DeleteBindWithTrainer), Name = nameof(DeleteBindWithTrainer))]
        public async Task<ActionResult> DeleteBindWithTrainer([FromQuery] SetBindWithTrainerDto model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return Json(ModelState);

            await _centerManager.DeleteBindWithTrainerAsync(model, cancellationToken);

            return RedirectToAction(nameof(GetInfoCenter), new { isnCenter = model.IsnCenter });
        }

        #endregion

        #region Trainer 

        [HttpGet(nameof(GetListTrainers), Name = nameof(GetListTrainers))]
        public async Task<ActionResult<TrainerDto[]>> GetListTrainers()
        {
            var list = await _trainerManager.GetListTrainersAsync(new TrainerFilter());

            return View(list);
        }

        [HttpGet(nameof(GetInfoTrainer), Name = nameof(GetInfoTrainer))]
        public async Task<ActionResult<InfoTrainerDto>> GetInfoTrainer([FromQuery, Required] Guid isnTrainer)
        {
            var model = await _trainerManager.GetInfoTrainerAsync(isnTrainer);

            return View(model);
        }


        [HttpGet(nameof(Trainer), Name = nameof(Trainer))]
        public ActionResult Trainer()
        {
            return View(new EditTrainerDto());
        }

        [HttpGet(nameof(GetEditTrainer), Name = nameof(GetEditTrainer))]
        public async Task<ActionResult<EditTrainerDto>> GetEditTrainer([FromQuery, Required] Guid isnTrainer)
        {
            var model = await _trainerManager.GetTrainerAsync(isnTrainer);

            return View(nameof(Trainer), model);
        }

        [HttpPost(nameof(CreateTrainer), Name = nameof(CreateTrainer))]
        public async Task<ActionResult> CreateTrainer([FromForm] EditTrainerDto model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(nameof(Trainer), model);

            await _trainerManager.CreateTrainerAsync(model, cancellationToken);

            return RedirectToAction(nameof(GetListTrainers));
        }

        [HttpPost(nameof(UpdateTrainer), Name = nameof(UpdateTrainer))]
        public async Task<ActionResult> UpdateTrainer([FromForm] EditTrainerDto model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(nameof(Trainer), model);

            await _trainerManager.UpdateTrainerAsync(model, cancellationToken);

            return RedirectToAction(nameof(GetListTrainers));
        }

        [HttpGet(nameof(DeleteTrainer), Name = nameof(DeleteTrainer))]
        public async Task<ActionResult> DeleteTrainer([FromQuery, Required] Guid isnTrainer, CancellationToken cancellationToken)
        {
            await _trainerManager.DeleteTrainerAsync(isnTrainer, cancellationToken);

            return RedirectToAction(nameof(GetListTrainers));
        }

        [HttpPost(nameof(SetBindWithCustomer), Name = nameof(SetBindWithCustomer))]
        public async Task<ActionResult> SetBindWithCustomer([FromBody] SetBindWithCustomerDto model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return Json(ModelState);

            await _trainerManager.SetBindWithCustomerAsync(model, cancellationToken);

            return Ok();
        }

        // todo: лучше переделать post и передавать данные через ajax, НО для упрощения сделано через get
        [HttpGet(nameof(DeleteBindWithCustomer), Name = nameof(DeleteBindWithCustomer))]
        public async Task<ActionResult> DeleteBindWithCustomer([FromQuery] SetBindWithCustomerDto model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return Json(ModelState);

            await _trainerManager.DeleteBindWithCustomerAsync(model, cancellationToken);

            return RedirectToAction(nameof(GetInfoTrainer), new { isnTrainer = model.IsnTrainer });
        }

        #endregion

        #region Customer

        [HttpGet(nameof(GetListCustomer), Name = nameof(GetListCustomer))]
        public async Task<ActionResult<CustomerDto[]>> GetListCustomer()
        {
            var filter = new CustomerFilter();
            var list = await _customerManager.GetListCustomersAsync(filter);

            return View(list);
        }

        [HttpGet(nameof(GetInfoCustomer), Name = nameof(GetInfoCustomer))]
        public async Task<ActionResult<InfoCustomerDto>> GetInfoCustomer([FromQuery, Required] Guid isnCustomer)
        {
            var model = await _customerManager.GetInfoCustomerAsync(isnCustomer);

            return View(model);
        }

        [HttpGet(nameof(Customer), Name = nameof(Customer))]
        public ActionResult Customer(Guid isnCenter)
        {
            return View(new EditCustomerDto { IsnCenter = isnCenter });
        }

        [HttpGet(nameof(GetEditCustomer), Name = nameof(GetEditCustomer))]
        public async Task<ActionResult<EditCustomerDto>> GetEditCustomer([FromQuery, Required] Guid isnCustomer)
        {
            var model = await _customerManager.GetCustomerAsync(isnCustomer);

            return View(nameof(Customer), model);
        }

        [HttpPost(nameof(CreateCustomer), Name = nameof(CreateCustomer))]
        public async Task<ActionResult> CreateCustomer([FromForm] EditCustomerDto model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(nameof(Customer), model);

            await _customerManager.CreateCustomerAsync(model, cancellationToken);

            return RedirectToAction(nameof(GetListCustomer));
        }

        [HttpPost(nameof(UpdateCustomer), Name = nameof(UpdateCustomer))]
        public async Task<ActionResult> UpdateCustomer([FromForm] EditCustomerDto model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(nameof(Customer), model);

            await _customerManager.UpdateCustomerAsync(model, cancellationToken);

            return RedirectToAction(nameof(GetInfoCustomer), new { isnCustomer = model.IsnNode });
        }

        [HttpGet(nameof(DeleteCustomer), Name = nameof(DeleteCustomer))]
        public async Task<ActionResult> DeleteCustomer([FromQuery, Required] Guid isnCustomer, CancellationToken cancellationToken)
        {
            var model = await _customerManager.DeleteCustomerAsync(isnCustomer, cancellationToken);

            return RedirectToAction(nameof(GetListCustomer));
        }

        #endregion
    }
}
