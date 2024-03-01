using AutoStock.Data;

namespace AutoStock.Tool.ConstantGenerators;

internal class CodeCategoryConstantGenerator : BaseConstantGenerator<CodeCategory>
{
    protected override string EntityName => nameof(CodeCategory);

    protected override List<CodeCategory> Load() => Dao.CodeCategory.Get().FindAll(x => x.CodeCategoryId != 0);

    protected override string GetLiteral(CodeCategory item) => $"{item.Text.Clean()}_{item.CodeCategoryId}";

    protected override string GetValue(CodeCategory item) => $"{item.CodeCategoryId}";
}