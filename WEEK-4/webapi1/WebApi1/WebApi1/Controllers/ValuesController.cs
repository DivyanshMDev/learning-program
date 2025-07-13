//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace WebApi1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ValuesController : ControllerBase
//    {
//    }
//}

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    // Static list to simulate database
    private static List<string> values = new List<string> { "value1", "value2" };

    // GET: api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        return Ok(values);
    }

    // GET: api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        if (id < 0 || id >= values.Count)
            return NotFound();

        return Ok(values[id]);
    }

    // POST: api/values
    [HttpPost]
    public ActionResult Post([FromBody] string value)
    {
        if (string.IsNullOrEmpty(value))
            return BadRequest("Value cannot be empty");

        values.Add(value);
        return CreatedAtAction(nameof(Get), new { id = values.Count - 1 }, value);
    }

    // PUT: api/values/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] string value)
    {
        if (id < 0 || id >= values.Count)
            return NotFound();

        if (string.IsNullOrEmpty(value))
            return BadRequest("Value cannot be empty");

        values[id] = value;
        return Ok();
    }

    // DELETE: api/values/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        if (id < 0 || id >= values.Count)
            return NotFound();

        values.RemoveAt(id);
        return Ok();
    }
}

