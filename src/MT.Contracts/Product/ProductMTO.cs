
namespace MT.Contracts.Product;

public record ProductCreation(string Name, string CategoryId, DateTime CreatedAt);

public record ProductModification(string Name, string CategoryId, DateTime UpdateAt);

public record ProductDeletion(string Name);