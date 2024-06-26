﻿using Domain.Entities;

namespace Repositories.Abstractions;

public interface IRepository<T, TPrimaryKey> where T : class, IEntity<TPrimaryKey>
{
    /// <summary>
    /// Получить сущность по ID.
    /// </summary>
    /// <param name="id"> Id сущности. </param>
    /// <returns> Cущность. </returns>
    T Get(TPrimaryKey id);

    /// <summary>
    /// Получить сущность по Id.
    /// </summary>
    /// <param name="id"> Id сущности. </param>
    /// <param name="cancellationToken"></param>
    /// <returns> Cущность. </returns>
    Task<T> GetAsync(TPrimaryKey id, CancellationToken cancellationToken);

    /// <summary>
    /// Запросить все сущности в базе.
    /// </summary>
    /// <param name="asNoTracking"> Вызвать с AsNoTracking. </param>
    /// <returns> IQueryable массив сущностей. </returns>
    IQueryable<T> GetAll(bool asNoTracking = false);

    /// <summary>
    /// Запросить все сущности в базе.
    /// </summary>
    /// <param name="cancellationToken"> Токен отмены </param>
    /// <param name="asNoTracking"> Вызвать с AsNoTracking. </param>
    /// <returns> Список сущностей. </returns>
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false);

    /// <summary>
    /// Добавить в базу сущность.
    /// </summary>
    /// <param name="entity"> Cущность для добавления. </param>
    /// <returns>. Добавленная сущность. </returns>
    T Add(T entity);

    /// <summary>
    /// Добавить в базу одну сущность.
    /// </summary>
    /// <param name="entity"> Сущность для добавления. </param>
    /// <returns> Добавленная сущность. </returns>
    Task<T> AddAsync(T entity);

    /// <summary>
    /// Добавить в базу массив сущностей.
    /// </summary>
    /// <param name="entities"> Массив сущностей. </param>
    void AddRange(List<T> entities);

    /// <summary>
    /// Добавить в базу массив сущностей.
    /// </summary>
    /// <param name="entities"> Массив сущностей. </param>
    Task AddRangeAsync(ICollection<T> entities);

    /// <summary>
    /// Для сущности проставить состояние - что она изменена.
    /// </summary>
    /// <param name="entity"> Сущность для изменения. </param>
    void Update(T entity);

    /// <summary>
    /// Удалить сущность.
    /// </summary>
    /// <param name="id"> Id удалённой сущности. </param>
    /// <returns> Была ли сущность удалена. </returns>
    bool Delete(TPrimaryKey id);

    /// <summary>
    /// Удалить сущность.
    /// </summary>
    /// <param name="entity"> Сущность для удаления. </param>
    /// <returns> Была ли сущность удалена. </returns>
    bool Delete(T entity);

    /// <summary>
    /// Удалить сущности.
    /// </summary>
    /// <param name="entities"> Коллекция сущностей для удаления. </param>
    /// <returns> Была ли операция завершена успешно. </returns>
    bool DeleteRange(ICollection<T> entities);

    /// <summary>
    /// Сохранить изменения.
    /// </summary>
    void SaveChanges();

    /// <summary>
    /// Сохранить изменения.
    /// </summary>
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}