# Task-Lister
ASP.Net Based Rest API with CRUD Operations
<div align="">

# Overview

In this Project, I have built a CRUD REST API from scratch using .NET 7.
he backend system supports Creating, Reading, Updating and Deleting Tasks.

# Usage

Simply `git clone https://github.com/kanha638/Task-Lister.git` and `dotnet run --project TaskList`.

# API Definition


## Create Task

### Create Task Request

```js
POST /task
```

```json
{
    "name": "Task Name",
    "description": "Task Description goes here .... ",
    "startDateTime": "2023-02-03T08:00:00",
    "endDateTime": "2023-02-03T11:00:00",
    "tags": [
        "important",
        "urgent",
        "office"
    ]
}
```

### Create Task Response

```js
201 Created
```

```yml
Location: {{host}}/task/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Task Name",
    "description": "Task Description goes here ....",
    "startDateTime": "2023-02-03T08:00:00",
    "endDateTime": "2023-02-03T11:00:00",
    "lastModifiedDateTime": "2023-02-04T12:00:00",
     "tags": [
        "important",
        "urgent",
        "office"
    ]
}
```

## Get Task

### Get Task Request

```js
GET /task/{{id}}
```

### Get Task Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Task Name",
    "description": "Task Description goes here ....",
    "startDateTime": "2023-02-03T08:00:00",
    "endDateTime": "2023-02-03T11:00:00",
    "lastModifiedDateTime": "2023-02-03T12:00:00",
    "tags": [
        "important",
        "urgent",
        "office"
    ]
}
```

## Update Task

### Update Task Request

```js
PUT /task/{{id}}
```

```json
{
    "name": "Task Name",
    "description": "Task Description goes here ....",
    "startDateTime": "2023-02-03T08:00:00",
    "endDateTime": "2023-02-03T11:00:00",
   "tags": [
        "important",
        "urgent",
        "office"
    ]
}
```

### Update Task Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/task/{{id}}
```

## Delete Task

### Delete Task Request

```js
DELETE /task/{{id}}
```

### Delete Task Response

```js
204 No Content
```

