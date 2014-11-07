using MonoTouch.UIKit;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedDemo.iOS.TableSources
{
    public class SessionUITableSource :  UITableViewSource 
    {
        private List<Session> _sessions = null;
        private UITableViewController _tvc = null;
        string cellIdentifier = "TableCell";

        public SessionUITableSource(UITableViewController tvc, List<Session> sessions)
        {
            _sessions = sessions;
            _tvc = tvc;
        }
        
        public override UITableViewCell GetCell(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
        {

            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            // if there are no cells to reuse, create a new one
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);
            
            cell.TextLabel.Text = _sessions[indexPath.Row].Title;
            cell.DetailTextLabel.Text = _sessions[indexPath.Row].Abstract;

            return cell;
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return _sessions.Count;
        }
    }
}
