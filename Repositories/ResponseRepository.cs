class ResponseRepository : IResponseRepository
{
	private readonly Dictionary<Guid, Response> _response = new();

	public void Create(Response response)
	{
		if (response is null) return;
		_response[response.Id] = response;
	}

	public Response GetById(Guid id)
	{
		return _response[id];
	}

	public List<Response> GetAll()
	{
		return _response.Values.ToList();
	}

	public void Update(Response response)
	{
		var existingResponse = GetById(response.Id);
		if (existingResponse is null) return;
		_response[response.Id] = response;
	}

	public void Delete(Guid id)
	{
		_response.Remove(id);
	}
}