using System.Text.Json;

namespace $safeprojectname$.Builders.Base;

/// <summary>
/// Constructor de elementos base
/// </summary>
/// <typeparam name="T">Tipo de la clase que implementa <see cref="BuilderBase{T, TDto}"/> </typeparam>
/// <typeparam name="TDto">Tipo del Dto</typeparam>
public abstract class BuilderBase<T, TDto>
    where T : BuilderBase<T, TDto>
    where TDto : new()
{
    protected TDto Entity { get; private set; } = new TDto();

    /// <summary>
    /// Inicializa el Dto
    /// </summary>
    protected void Clear()
    {
        Entity = new TDto();
    }

    /// <summary>
    /// Construye el Dto
    /// </summary>
    public virtual TDto Build()
    {
        var result = JsonSerializer.Deserialize<TDto>(JsonSerializer.Serialize(Entity));
        Clear();
        return result!;
    }
}