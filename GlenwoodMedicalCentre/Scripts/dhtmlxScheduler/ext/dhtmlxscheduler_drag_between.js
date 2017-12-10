/*
@license
dhtmlxScheduler.Net v.3.3.10 

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) Dinamenta, UAB.
*/
Scheduler._external_drag={from_scheduler:null,to_scheduler:null,drag_data:null,drag_placeholder:null,delete_dnd_holder:function(){var e=this.drag_placeholder;e&&(e.parentNode&&e.parentNode.removeChild(e),document.body.className=document.body.className.replace(" dhx_no_select",""),this.drag_placeholder=null)},copy_event_node:function(e,t){for(var i=null,n=0;n<t._rendered.length;n++){var a=t._rendered[n];if(a.getAttribute("event_id")==e.id||a.getAttribute("event_id")==t._drag_id){i=a.cloneNode(!0),
i.style.position=i.style.top=i.style.left="";break}}return i||document.createElement("div")},create_dnd_holder:function(e,t){if(this.drag_placeholder)return this.drag_placeholder;var i=document.createElement("div"),n=t.templates.event_outside(e.start_date,e.end_date,e);return n?i.innerHTML=n:i.appendChild(this.copy_event_node(e,t)),i.className="dhx_drag_placeholder",i.style.position="absolute",this.drag_placeholder=i,document.body.appendChild(i),document.body.className+=" dhx_no_select",i},move_dnd_holder:function(e){
var t={x:e.clientX,y:e.clientY};if(this.create_dnd_holder(this.drag_data.ev,this.from_scheduler),this.drag_placeholder){var i=t.x,n=t.y,a=document.documentElement,s=document.body,r=this.drag_placeholder;r.style.left=10+i+(a&&a.scrollLeft||s&&s.scrollLeft||0)-(a.clientLeft||0)+"px",r.style.top=10+n+(a&&a.scrollTop||s&&s.scrollTop||0)-(a.clientTop||0)+"px"}},clear_scheduler_dnd:function(e){e._drag_id=e._drag_mode=e._drag_event=e._new_event=null},stop_drag:function(e){e&&this.clear_scheduler_dnd(e),
this.delete_dnd_holder(),this.drag_data=null},inject_into_scheduler:function(e,t,i){e._count=1,e._sorder=0,e.event_pid&&"0"!=e.event_pid&&(e.event_pid=null,e.rec_type=e.rec_pattern="",e.event_length=0),t._drag_event=e,t._events[e.id]=e,t._drag_id=e.id,t._drag_mode="move",i&&t._on_mouse_move(i)},start_dnd:function(e){if(e.config.drag_out){this.from_scheduler=e,this.to_scheduler=e;var t=this.drag_data={};t.ev=e._drag_event,t.orig_id=e._drag_event.id}},land_into_scheduler:function(e,t){if(!e.config.drag_in)return this.move_dnd_holder(t),
!1;var i=this.drag_data,n=e._lame_clone(i.ev);if(e!=this.from_scheduler){n.id=e.uid();var a=n.end_date-n.start_date;n.start_date=new Date(e.getState().min_date),n.end_date=new Date(n.start_date.valueOf()+a)}else n.id=this.drag_data.orig_id,n._dhx_changed=!0;return this.drag_data.target_id=n.id,e.callEvent("onBeforeEventDragIn",[n.id,n,t])?(this.to_scheduler=e,this.inject_into_scheduler(n,e,t),this.delete_dnd_holder(),e.updateView(),e.callEvent("onEventDragIn",[n.id,n,t]),!0):!1},drag_from_scheduler:function(e,t){
if(this.drag_data&&e._drag_id&&e.config.drag_out){if(this.to_scheduler==e&&(this.to_scheduler=null),!e.callEvent("onBeforeEventDragOut",[e._drag_id,e._drag_event,t]))return!1;this.create_dnd_holder(this.drag_data.ev,e);var i=e._drag_id;return this.drag_data.target_id=null,delete e._events[i],this.clear_scheduler_dnd(e),e.updateEvent(i),e.callEvent("onEventDragOut",[i,this.drag_data.ev,t]),!0}return!1},reset_event:function(e,t){this.inject_into_scheduler(e,t),this.stop_drag(t),t.updateView()},move_permanently:function(e,t,i,n){
n.callEvent("onEventAdded",[t.id,t]),this.inject_into_scheduler(e,i),this.stop_drag(i),e.event_pid&&"0"!=e.event_pid?(i.callEvent("onConfirmedBeforeEventDelete",[e.id]),i.updateEvent(t.event_pid)):i.deleteEvent(e.id),i.updateView(),n.updateView()}},dhtmlxEvent(window,"load",function(){dhtmlxEvent(document.body,"mousemove",function(e){var t=Scheduler._external_drag,i=t.target_scheduler;if(i)if(t.from_scheduler)if(i._drag_id);else{var n=t.to_scheduler;(!n||t.drag_from_scheduler(n,e))&&t.land_into_scheduler(i,e);

}else"move"==i.getState().drag_mode&&i.config.drag_out&&t.start_dnd(i);else t.from_scheduler&&(t.to_scheduler?t.drag_from_scheduler(t.to_scheduler,e):t.move_dnd_holder(e));t.target_scheduler=null}),dhtmlxEvent(document.body,"mouseup",function(e){var t=Scheduler._external_drag,i=t.from_scheduler,n=t.to_scheduler;if(i)if(n&&i==n)i.updateEvent(t.drag_data.target_id);else if(n&&i!==n){var a=t.drag_data.ev,s=n.getEvent(t.drag_data.target_id);i.callEvent("onEventDropOut",[a.id,a,n,e])?t.move_permanently(a,s,i,n):t.reset_event(a,i);

}else{var a=t.drag_data.ev;i.callEvent("onEventDropOut",[a.id,a,null,e])&&t.reset_event(a,i)}t.stop_drag(),t.current_scheduler=t.from_scheduler=t.to_scheduler=null})}),Scheduler.plugin(function(e){e.config.drag_in=!0,e.config.drag_out=!0,e.templates.event_outside=function(e,t,i){};var t=Scheduler._external_drag;e.attachEvent("onTemplatesReady",function(){dhtmlxEvent(e._obj,"mousemove",function(i){t.target_scheduler=e}),dhtmlxEvent(e._obj,"mouseup",function(i){t.target_scheduler=e})})});