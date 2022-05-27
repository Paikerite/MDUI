using System;
using System.ComponentModel;

public class Skills
{
    private int id;
    private string skill;

    public int Id
    {
        get { return id; }
        set
        {
            if (id != value)
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }
    }

    public string Skill
    {
        get { return skill; }
        set
        {
            if (skill != value)
            {
                skill = value;
                NotifyPropertyChanged("Skill");
            }
        }
    }

    public override string ToString()
    {
        return string.Format("{1}", Id, Skill);
    }

    public virtual event PropertyChangedEventHandler PropertyChanged;
    protected virtual void NotifyPropertyChanged(params string[] propertyNames)
    {
        if (PropertyChanged != null)
        {
            foreach (string propertyName in propertyNames) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            PropertyChanged(this, new PropertyChangedEventArgs("HasError"));
        }
    }
}