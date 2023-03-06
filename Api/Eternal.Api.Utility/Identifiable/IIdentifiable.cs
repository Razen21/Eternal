namespace Eternal.Api.Utility.Identifiable;

public interface IIdentifiable<out T>
{
    T Id { get; }
}