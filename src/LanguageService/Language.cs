using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;
using System.Runtime.InteropServices;

namespace MarkdownEditor
{
    [Guid("ecf70314-91e6-490d-8ea3-45e82b2d28e9")]
    public class MarkdownLanguage : LanguageService
    {
        private LanguagePreferences preferences = null;

        public override LanguagePreferences GetLanguagePreferences()
        {
            if (preferences == null)
            {
                preferences = new LanguagePreferences(this.Site, typeof(MarkdownLanguage).GUID, this.Name);

                if (preferences != null)
                {
                    preferences.Init();

                    preferences.EnableCodeSense = true;
                    preferences.EnableMatchBraces = true;
                    preferences.EnableCommenting = true;
                    preferences.EnableShowMatchingBrace = true;
                    preferences.EnableMatchBracesAtCaret = true;
                    preferences.HighlightMatchingBraceFlags = _HighlightMatchingBraceFlags.HMB_USERECTANGLEBRACES;
                    preferences.LineNumbers = true;
                    preferences.MaxErrorMessages = 100;
                    preferences.AutoOutlining = false;
                    preferences.MaxRegionTime = 2000;
                    preferences.ShowNavigationBar = true;
                    preferences.InsertTabs = false;
                    preferences.IndentSize = 2;

                    preferences.AutoListMembers = true;
                    preferences.EnableQuickInfo = true;
                    preferences.ParameterInformation = true;
                }
            }

            return preferences;
        }

        public override IScanner GetScanner(IVsTextLines buffer)
        {
            throw new System.NotImplementedException();
        }

        public override AuthoringScope ParseSource(ParseRequest req)
        {
            throw new System.NotImplementedException();
        }

        public override string GetFormatFilterList()
        {
            return "Markdown File (*.markdown, *.md, *.mdown, *.mdwn, *.mkd, *.mkdn, *.mmd)|*.markdown;*.md;*.mdown;*.mdwn;*.mdwn;*.mkd;*.mkdn;*.mmd";
        }

        public override string Name => MarkdownContentTypeDefinition.MarkdownContentType;

        public override void Dispose()
        {
            try
            {
                if (preferences != null)
                {
                    preferences.Dispose();
                    preferences = null;
                }
            }
            finally
            {
                base.Dispose();
            }
        }
    }
}