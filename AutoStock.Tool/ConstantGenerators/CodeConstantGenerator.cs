using AutoStock.Data;

namespace AutoStock.Tool.ConstantGenerators;

internal class CodeConstantGenerator : BaseConstantGenerator<Code>
{
    protected override string EntityName => "C";

    protected override List<Code> Load() 
        => Dao.Code.Get().FindAll(x => x.CodeId != 0);

    protected override string GetLiteral(Code item)
    {
        int prefix = item.CodeId / 100;
        return $"_{prefix}_{item.Text.Clean()}";
    }

    protected override string GetValue(Code item) => $"{item.CodeId}";
}