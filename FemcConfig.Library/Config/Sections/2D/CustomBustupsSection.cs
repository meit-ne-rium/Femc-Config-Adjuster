using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class CustomBustupsSection : ISection
{
    public string Name { get; } = Localisation.LocalisationResources.Resources.CustomBustups;

    public string Description { get; } = Localisation.LocalisationResources.Resources.CustomBustupsDesc;

    public SectionCategory Category { get; } = SectionCategory.TwoD;

    public ModOption[] Options { get; }

    public CustomBustupsSection(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "ryoji_bustup",
                Name = "Front Facing Ryoji",
                Authors = [Author.Femc],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.CustomBustups = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.CustomBustups = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.CustomBustups,
            }
        ];
    }
}
