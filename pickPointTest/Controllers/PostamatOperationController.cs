using Microsoft.AspNetCore.Mvc;
using pickPointTest.Contracts.Requests;
using pickPointTest.Contracts.Responses;
using pickPointTest.Services;
using System;
using System.Threading.Tasks;

namespace pickPointTest.Controllers
{
    public class PostamatOperationController: Controller
    {
        private IPostamatService _postamatService;

        public PostamatOperationController(IPostamatService postamatService)
        {
            _postamatService = postamatService;
        }

        [HttpGet("api/GetEnablePostamats")]
        public async Task<IActionResult> GetEnablePostamats()
        {
            try
            {
                var result = await _postamatService.GetEnablePostamats();
                if (result.Count > 0)
                    return Ok(result);
                return NotFound();
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("api/GetPostamatInfo")]
        public async Task<IActionResult> GetPostamatInfo(PostamatInfoRequest pir)
        {
            try
            {
                var result = await _postamatService.GetPostamatInfo(pir);
                if (result != null)
                    return Ok(new PostamatInfoResponse
                    {
                        postamatNumber = result.pNumber,
                        postamatAddress = result.pAddress,
                        postamatStatus = result.pStatus
                    });
                return NotFound();
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
