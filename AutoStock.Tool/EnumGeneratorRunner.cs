using System.Text;
using AutoStock.Data;

namespace AutoStock.Tool;

public class EnumGeneratorRunner : ITool
{
    public string PathToWrite => @"d:\stock\stock\AutoStock\AutoStock.Data\Generated\E.generated.cs";

    public const string OuterTemplate = """
                                        namespace EasyRepick.Data;

                                        public class E
                                        {{
                                            {0}
                                        }}
                                        """;

    public const string CategoryTemplate = """
                                           public enum {0}
                                           {{
                                               {1}
                                           }}
                                           """;

    public const string CodeTemplate = """
                                           {0} = {1},
                                       """;

    private readonly List<CodeCategory> _categories = Dao.CodeCategory.Get();
    
    private readonly List<Code> _codes = Dao.Code.Get();

    public void Run()
    {
        StringBuilder categoryBuilder = new();

        foreach (var category in _categories.Where(x => x.CodeCategoryId != 0))
        {
            StringBuilder codeBuilder = new();

            var codes = _codes.FindAll(x => x.CodeCategoryId == category.CodeCategoryId);
            foreach (var code in codes)
                codeBuilder.AppendFormat(CodeTemplate, code.Text.Clean(), code.CodeId);

            categoryBuilder.AppendFormat(CategoryTemplate, category.Text.Clean(), codeBuilder);
        }

        string text = string.Format(OuterTemplate, categoryBuilder);

        File.WriteAllText(PathToWrite, text);
    }

    public string Description() => "열거형 생성";
}