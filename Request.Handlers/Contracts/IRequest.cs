namespace Request.Handlers.Contracts;

public interface IRequest { }
public interface IRequest<out TResponse> { }