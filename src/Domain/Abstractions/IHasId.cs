namespace GraduationProject.Domain.Abstractions;

public interface IHasId<out T>
{
    public T Id { get; }
}
