interface IResponseRepository
{
	void Create(Response response);
	Response GetById(Guid id);
	List<Response> GetAll();
	void Update(Response response);
	void Delete(Guid id);
}