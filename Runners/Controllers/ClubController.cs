using Booking.com.Filters;
using Booking.com.Interfaces;
using Booking.com.ViewModels;
using DataAccessLayer.Repos;
using DomainLayer.Interfaces;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booking.com.Controllers
{
    public class ClubController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClubRepository _clubRepository;
        private readonly IPhotoService _photoService;
        public ClubController(IUnitOfWork unitOfWork, IClubRepository clubRepository, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _clubRepository = clubRepository;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            List<Club> clubs = (List<Club>)await _clubRepository.GetAll();
            return View(clubs);
        }
        public async Task<IActionResult> Details(int id)
        {
            var club = await _clubRepository.GetAsync(id);
            return View(club);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateClubViewModel clubvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(clubvm.Image);
                var club = new Club
                {
                    Title = clubvm.Title,
                    Description = clubvm.Description,
                    Image = result.Url.ToString(),
                    ClubCategory = clubvm.ClubCategory,
                    Address = new Address
                    {
                        City = clubvm.Address.City,
                        Street = clubvm.Address.Street
                    }
                };
                await _clubRepository.Add(club);
                _unitOfWork.CommitChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "photo upload failed");
            }
            return View(clubvm);
        }


        public async Task<IActionResult> Update(int id)
        {
            var club = await _clubRepository.GetAsync(id);
            if (club is null) return View("Error");
            var clubVM = new UpdateClubViewModel
            {
                Title = club.Title,
                Description = club.Description,
                Address = club.Address,
                ClubCategory = club.ClubCategory
            };
            return View(clubVM);            
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateClubViewModel clubvm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed To Update");
                return View("Update", clubvm);
            }
            var club = await _clubRepository.GetByIdWithNoTrakingAsync(id);
            if (club is null)
            {
                try
                {
                    await _photoService.DeletionPhotoAsync(club.Image);
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Unable to delete the pic");
                    return View();
                }

                var photoresult = await _photoService.AddPhotoAsync(clubvm.Image);
                var updatedclub = new Club
                {
                    Title = clubvm.Title,
                    Description = clubvm.Description,
                    AddressID = club.AddressID,
                    Address = club.Address,
                    Image = photoresult.Url.ToString(),
                    ClubCategory = clubvm.ClubCategory
                };
                _clubRepository.Update(updatedclub);
                _unitOfWork.CommitChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Update", clubvm.ID);
            }
        }
    }
}