//提供一些函数，用来操作Index页面的全局变量TaskLink

//插入医保数据到TaskLink
function tasklinkinsert(data)
{
    //这里我们执行的是拷贝,如果是对象必须要拷贝,否则指向的都是同一个东西
    var tempData = deepCopy(data);
    var node = { "data": tempData,"model":"yb", "name": tempData.transType, "callCount": 0, "type": "POST" };
    var next = "";
    var task = { "node": node, "next": next };
    tasklinkpush(task);
}

//插入电子医保到TaskLink中
function tasklinkinsertWX(data)
{
    //这里我们执行的是拷贝,如果是对象必须要拷贝,否则指向的都是同一个东西
    var tempData = deepCopy(data.data);
    var node = { "data": tempData,"model":"wx", "name": data.transType, "callCount": 0, "type": (data.Type == undefined ? "POST" : data.Type), "API_URL": data.API_URL };
    var next = "";
    var task = { "node": node, "next": next };
    tasklinkpush(task);
}

//对象深拷贝,因为对象里面可能还包含了对象,所以搞一个递归
function deepCopy(obj) {
    if (typeof obj != 'object') {
        return obj;
    }
    if (obj instanceof Array) {
        var newobj = [];
    } else {
        var newobj = {};
    }

    for (var attr in obj) {
        if (obj instanceof Array) {            
            newobj.push(deepCopy(obj[attr]));
        } else {         
            newobj[attr] = deepCopy(obj[attr]);
        }        
    }
    return newobj;
}

//插入尾节点
function tasklinkpush(task)
{
    if (tasklinklength() > 0) {
        var lowtask = tasklinklow();
        lowtask.next = task;
    } else {
        TaskLink = task;
    }    
}

//删除头节点
function tasklinkdelete()
{
    if (tasklinklength() > 1) {
        var task = TaskLink.next;
        TaskLink = task;
    } else {
        TaskLink = undefined;
    }
}

//获取未节点
function tasklinklow()
{
    if (TaskLink == undefined || TaskLink.node == undefined)
    {
        return undefined;
    }   
    var task = TaskLink;
    while (task.next != undefined && task.next != "") {
        task = task.next;       
    }
    return task;
}
 
//获取链表长度
function tasklinklength()
{
    if (TaskLink == undefined || TaskLink.node == undefined)
    {
        return 0;
    }
    var count = 1;
    var task = TaskLink;
    while (task.next != undefined && task.next != "")
    {
        task = task.next;
        count += 1;
    }
    return count;
}

//清空链表
function tasklinkclear()
{
    TaskLink = undefined;
}

