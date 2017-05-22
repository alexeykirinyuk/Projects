﻿var host = "http://localhost:56257/";

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
    href("Workers/Create");
}
function editWorker(id)
{
    href("Workers/Edit?id=" + id);
}
function detailsWorker(id)
{
    href("Workers/Details?id=" + id);
}
function removeWorker(id)
{
    href("Workers/Remove?id=" + id);
}

function sort(row)
{
    var table, rows, switching, i, x, y, shouldSwitch;
    table = document.getElementById("projects");
    switching = true;

    while (switching)
    {
        switching = false;
        rows = table.getElementsByTagName("TR");

        for (i = 1; i < (rows.length - 1); i++)
        {
            shouldSwitch = false;

            x = rows[i].getElementsByTagName("TD")[0];
            y = rows[i + 1].getElementsByTagName("TD")[0];

            if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase())
            {
                shouldSwitch = true;
                break;
            }
        }
        if (shouldSwitch)
        {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
        }
    }
}