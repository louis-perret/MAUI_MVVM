using CommunityToolkit.Maui.Views;
using ViewModel;

namespace Views.ContentViews;

public partial class AddSkill : Popup
{
	public SkillVM Skill { get; private set; }

	public AddSkill()
	{
		InitializeComponent();
		Skill = new SkillVM();
;		BindingContext = Skill;
		Size = new Size(300, 250);
	}

    void Confirm(object? sender, EventArgs e) => Close(Skill);

    void Cancel(object? sender, EventArgs e) => Close();
}
