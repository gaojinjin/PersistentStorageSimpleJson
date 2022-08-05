using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;
public class SimpleJsonManager : MonoBehaviour
{
    public string fileName;
    void Start()
    {
        List<Book> books = new List<Book>();
        books.Add(new Book(12,"Î÷ÓÎ¼Ç","Îâ³Ð¶÷"));
        books.Add(new Book(12,"ºìÂ¥ÃÎ","²ÜÑ©ÇÛ"));

        JSONNode root = new JSONObject();
        JSONNode nodeArr = new JSONArray();
        for (int i = 0; i < books.Count; i++)
        {
            JSONNode child = new JSONObject();
            child.Add("ID", books[i].id);
            child.Add("Name", books[i].name);
            child.Add("Author", books[i].author);
            nodeArr.Add(child);
        }
        root.Add("Books", nodeArr);
        string filePath = Application.streamingAssetsPath + "/" + fileName + ".json";
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }
        File.WriteAllText(filePath,root.ToString());
    }

}
public class Book {
    public int id;
    public string name;
    public string author;

    public Book(int id, string name, string author)
    {
        this.id = id;
        this.name = name;
        this.author = author;
    }
}