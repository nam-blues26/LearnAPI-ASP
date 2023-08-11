using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
           
        }

        //[HttpGet("{id}")]
        //public IActionResult EditById(string id, HangHoa hangHoaEdit)
        //{
        //    try
        //    {
        //        var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
        //        if (hangHoa == null)
        //        {
        //            return NotFound();
        //        }

        //        if (id != hangHoa.MaHangHoa.ToString())
        //        {
        //            return BadRequest();
        //        }
        //        hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
        //        hangHoa.DonGia = hangHoaEdit.DonGia;
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }

        //}

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                Success = true, Data = hanghoa
            });
        }
    }
}
