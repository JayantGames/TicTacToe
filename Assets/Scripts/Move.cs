using System.Collections;

public class Move {
    private int row;
    private int column;
    private int value;

    public Move()
    {

    }

    public Move(int row, int column)
    {
        this.row = row;
        this.column = column;
    }

    public Move(int row, int column, int value)
    {
        this.row = row;
        this.column = column;
        this.value = value;
    }

    public void SetMove(Move m)
    {
        row = m.GetRow();
        column = m.GetColumn();
    }

    public void SetRow(int row)
    {
        this.row = row;
    }

    public int GetRow()
    {
        return row;
    }

    public void SetColummn(int column)
    {
        this.column = column;
    }

    public int GetColumn()
    {
        return column;
    }

    public void SetValue(int value)
    {
        this.value = value;
    }

    public int GetValue()
    {
        return value;
    }
}
