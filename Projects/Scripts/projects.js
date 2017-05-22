var host = "http://localhost:56257/";

function createProject()
{
    href("Projects/Create");
}
function editProject(id)
{
    href("Projects/Edit?id=" + id);
}
function removeProject(id)
{
    href("Projects/Remove?id=" + id);
}
function backToList()
{
    href("Projects/Index");
}
function detailsProject(id)
{
    href("Projects/Details?id=" + id);
}
function href(path)
{
    document.location.href = host + path;
}
