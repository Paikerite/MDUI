using System;
using System.ComponentModel;
//Template for combobobx choose skills
public class ItemCombobox
{
    private int id;
    private string item;

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

    public string Item
    {
        get { return item; }
        set
        {
            if (item != value)
            {
                item = value;
                NotifyPropertyChanged("Item");
            }
        }
    }

    public override string ToString()
    {
        return string.Format("{1}", Id, Item);
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