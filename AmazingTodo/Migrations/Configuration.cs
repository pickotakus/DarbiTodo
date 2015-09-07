using AmazingTodo.Models;

namespace AmazingTodo.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AmazingTodo.Models.AmazingTodoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AmazingTodoContext context)
        {
            var names = new List<string> { "Mâjas uzkopðanas darbi", "Iepirkðanâs", "Personîgie mçríi", "Darba lietas", "Atpûta ar draugiem" };            
            var r = new Random();
            int index = r.Next(names.Count);
            
            var items = Enumerable.Range(1, 50).Select(o => new TodoItem {
                DueDate = new DateTime(2012, r.Next(1, 12), r.Next(1, 27)),
                Priority = (byte)r.Next(10),
                Todo = names[index-1].ToString()
            }).ToArray();
            context.TodoItems.AddOrUpdate(item => new { item.Todo }, items);
        }
    }
}
