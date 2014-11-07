using MonoTouch.UIKit;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedDemo.iOS.TableSources
{
    public class EventUITableSource : UITableViewSource 
    {
        private List<Event> _events = null;
        private UITableViewController _tvc = null;
        string cellIdentifier = "TableCell";

        public EventUITableSource(UITableViewController tvc , List<Event> events)
        {
            _events = events;
            _tvc = tvc;
        }
        
        public override UITableViewCell GetCell(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
        {

            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            // if there are no cells to reuse, create a new one
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);
            
            cell.TextLabel.Text = _events[indexPath.Row].Name;
            cell.DetailTextLabel.Text = _events[indexPath.Row].Description;

            return cell;
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return _events.Count;
        }

        public override void RowSelected(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
        {
            // we selected an event, so now we navigate to second page with details
            EventsModel.Current.SelectedEventID = _events[indexPath.Row].EventId;
            _tvc.NavigationController.PushViewController(new EventDetailsViewController(),true);
        }
    }
}
