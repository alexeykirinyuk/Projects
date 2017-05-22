var host = "http://localhost:56257/";

function href(path)
{
    document.location.href = host + path;
}

function projects()
{
    href("Projects/Index");
}
function workers()
{
    href("Workers/Index");
}

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

function createWorker()
{
    href("Worker/Create");
}
function editWorker(id)
{
    href("Worker/Edit?id=" + id);
}
function removeWorker(id)
{
    href("Worker/Remove?id=" + id);
}
