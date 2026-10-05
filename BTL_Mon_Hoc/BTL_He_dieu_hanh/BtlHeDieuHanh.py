import psutil
import tkinter as tk
from tkinter import ttk,messagebox,scrolledtext 
from tkinter.ttk import Button
# import customtkinter as ctk
from datetime import datetime
import matplotlib.pyplot as plt
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
from matplotlib.figure import Figure
import tkinter.font as tkfont
from datetime import datetime

class moderntaskmanager(tk.Tk):
    def __init__(self):
        super().__init__()
        self.title("Task Manager Base")
        self.geometry("1400x900")
        self.configure(bg="#b7bdc4")

        self.update_interval=3000
        
       # Button(self,text="hello").pack(fill=tk.BOTH, expand=True, padx=10, pady=10)
        self.title_font=tkfont.Font(family='Segoe UI',size=14,weight="bold")
        self.button_font=tkfont.Font(family='Segoe UI',size=10,weight="bold")
        self.text_font=tkfont.Font(family='Segoe UI',size=10)

        self.style=ttk.Style()
        self.style.theme_use("clam")
        self.configure_styles()

        self.current_user=psutil.Process().username
        self.cpu_count=psutil.cpu_count()
        self.mem_total=round(psutil.virtual_memory().total/(1024**3),1)
        self.mem_used = round(psutil.virtual_memory().used / (1024**3), 1) 
        self.mem_percent = round(psutil.virtual_memory().percent, 1)

        self.columns=("pid","name","user","cpu","memory","status")
        self.process_cache=[]
        self.graph_data={'cpu':[],'mem':[],'disk':[],'network':[]}
        
        self.create_main_frame()
        self.create_header()
        self.create_control_panel()
        self.create_process_table()
        self.create_graph_panel()
        self.create_status_bar()
        self.update_data()
    def configure_styles(self):
        self.style.configure('TFrame', background='#f5f6f7')
        self.style.configure('Header.TFrame', background='#2c3e50')
        self.style.configure('Title.TLabel', 
                          font=self.title_font, 
                          foreground='yellow',
                          background="#3d8d3d")
        self.style.configure('Card.TFrame', 
                           background='white',
                           relief=tk.RAISED,
                           borderwidth=1)
        self.style.configure('Treeview', 
                           font=self.text_font,
                           rowheight=25,
                           fieldbackground='white',
                           background='white')
        self.style.configure('Treeview.Heading', 
                           font=self.button_font,
                           background="#971241",
                           foreground='white',
                           relief=tk.FLAT)
        self.style.map('Treeview', 
                     background=[('selected', "#25bf46")],
                     foreground=[('selected', 'black')])
        self.style.configure('TButton', 
                           font=self.button_font,
                           padding=6,
                           background="#0fa45a",
                           foreground='white')
        self.style.map('TButton',
                     background=[('active', "#b11ac8")])
        self.style.configure('Accent.TButton',
                           background='#e74c3c')
        self.style.map('Accent.TButton',
                     background=[('active', '#c0392b')])
    def create_main_frame(self):
       self.main_frame = ttk.Frame(self, style='TFrame')
       self.main_frame.pack(fill=tk.BOTH, expand=True, padx=10, pady=10)
    def create_header(self):
        header_frame = ttk.Frame(self.main_frame, style='Header.TFrame', height=60)
        header_frame.pack(fill=tk.X, pady=(0, 10))
        header_frame.pack_propagate(False)
        
        # App title
        title_label = ttk.Label(header_frame, text="Task Manager", style='Title.TLabel')
        title_label.pack(side=tk.LEFT, padx=20)
        # System info
        sys_info = ttk.Frame(header_frame, style='Header.TFrame')
        sys_info.pack(side=tk.RIGHT, padx=20)
        ttk.Label(sys_info, text=f"Memory: {self.mem_used}/{self.mem_total} GB ({self.mem_percent}%) | CPU: {self.cpu_count} ",style='Title.TLabel').pack()


    def create_control_panel(self):
        control_frame = ttk.Frame(self.main_frame, style='Card.TFrame')
        control_frame.pack(fill=tk.X, pady=(0, 10), ipady=5)


        filter_frame = ttk.Frame(control_frame, style='TFrame')
        filter_frame.pack(side=tk.LEFT, padx=20, pady=5)
        ttk.Label(filter_frame, text="Filter:", font=self.text_font).pack(side=tk.LEFT)
        self.filter_var = tk.StringVar(value="All")
        filter_combo = ttk.Combobox(filter_frame, textvariable=self.filter_var,values=["All", "Your", "Non-root", "Running"],width=12,state="readonly",font=self.text_font)
        filter_combo.pack(side=tk.LEFT, padx=5)
        self.filter_var.trace_add("write", lambda *_: self.update_processes())


        search_frame=ttk.Frame(control_frame,style='TFrame')
        search_frame.pack(side=tk.LEFT,padx=10,pady=5) 
        ttk.Label(search_frame,text="Search" ,font=self.text_font).pack(side=tk.LEFT)
        self.search_var = tk.StringVar()
        search_entry = ttk.Entry(search_frame, textvariable=self.search_var, width=30,font=self.text_font)
        search_entry.pack(side=tk.LEFT, padx=5)
        self.search_var.trace_add("write", lambda *_: self.update_processes())

        
        button_frame = ttk.Frame(control_frame, style='TFrame')
        button_frame.pack(side=tk.RIGHT, padx=10)
        ttk.Button(button_frame, text="Kill Process", command=self.kill_process,style='Accent.TButton').pack(side=tk.LEFT, padx=2)
        button_frame = ttk.Frame(control_frame, style='TFrame')
        button_frame.pack(side=tk.RIGHT, padx=10)
        ttk.Button(button_frame, text="Details", command=self.show_process_details,style='TButton').pack(side=tk.LEFT, padx=2)
        button_frame = ttk.Frame(control_frame, style='TFrame')
        button_frame.pack(side=tk.RIGHT, padx=10)
        ttk.Button(button_frame, text="Refresh", command=self.update_processes,style='TButton').pack(side=tk.LEFT, padx=2)
    # def kill_process(self):
      
    
    def create_process_table(self):
        """Create modern process table with better styling"""
        table_frame = ttk.Frame(self.main_frame, style='Card.TFrame')
        table_frame.pack(side=tk.LEFT,fill=tk.BOTH)
        
        # Treeview with scrollbars
        self.tree = ttk.Treeview(table_frame, columns=self.columns,show="headings",style='Treeview') # khi khong co show se hien them cot cay
        
        vsb = ttk.Scrollbar(table_frame, orient="vertical", command=self.tree.yview)
        hsb = ttk.Scrollbar(table_frame, orient="horizontal", command=self.tree.xview)
        self.tree.configure(yscrollcommand=vsb.set, xscrollcommand=hsb.set)
        
        # Configure columns
        col_widths = {"pid": 50, "name": 160, "user": 200, "cpu": 80, "memory": 60, "status": 60}
        for col in self.columns:
            self.tree.heading(col, text=col)
            self.tree.column(col, width=col_widths.get(col, 100), anchor=tk.W)
        
        # Grid layout
        self.tree.grid(row=0, column=0, sticky="nsew")
        vsb.grid(row=0, column=1, sticky="ns")
        hsb.grid(row=1, column=0, sticky="ew")
        
        table_frame.grid_rowconfigure(0, weight=1)
        table_frame.grid_columnconfigure(0, weight=1)
        
        # Bind double click event
        self.tree.bind("<Double-1>", self.show_process_details)

    def create_graph_panel(self):
        """Create modern graph panel with matplotlib"""
        graph_frame = ttk.Frame(self.main_frame, style='Header.TFrame')
        graph_frame.pack(fill=tk.BOTH, expand=True)
        
        # Create figure with dark theme
        plt.style.use('seaborn-v0_8')
        self.fig = Figure(figsize=(12, 4), dpi=100, facecolor='#f5f6f7')
        
        # Create subplots
        self.ax_cpu = self.fig.add_subplot(221) # do thi 1 co 1 hang 4 cot
        self.ax_mem = self.fig.add_subplot(222) # do thi 2 co 1 hang 4 cot
        self.ax_disk = self.fig.add_subplot(223)
        self.ax_network = self.fig.add_subplot(224)
        
        # Configure plots
        self.configure_plot(self.ax_cpu, "CPU Usage", "%", '#3498db')
        self.configure_plot(self.ax_mem, "Memory Usage", "%", '#2ecc71')
        self.configure_plot(self.ax_disk, "Disk Usage", "%", '#e74c3c')
        self.configure_plot(self.ax_network, "Network", "Mb/s", '#1c1c1b')
        
        # Create lines
        self.cpu_line, = self.ax_cpu.plot([], [], lw=2)
        self.mem_line, = self.ax_mem.plot([], [], lw=2)
        self.disk_line, = self.ax_disk.plot([], [], lw=2)
        self.network_line, = self.ax_network.plot([], [], lw=2)
        
        # Create canvas
        self.canvas = FigureCanvasTkAgg(self.fig, master=graph_frame)
        self.canvas.get_tk_widget().pack(fill=tk.BOTH, expand=True)

    def configure_plot(self, ax, title, ylabel, color):
        """Configure individual plot appearance"""
        ax.set_title(title, fontsize=10, pad=10)
        ax.set_ylabel(ylabel, fontsize=8)
        ax.set_facecolor('#ffffff')
        ax.grid(True, linestyle=':', alpha=0.7)
        ax.tick_params(labelsize=8)
        
        # Set colors
        for spine in ax.spines.values():
            spine.set_color(color)
        ax.title.set_color(color)
        ax.yaxis.label.set_color(color)
        ax.tick_params(axis='y', colors=color)
    def create_status_bar(self):
        """Create modern status bar"""
        status_frame = ttk.Frame(self.main_frame, style='Header.TFrame', height=30)
        status_frame.pack(fill=tk.X)
        status_frame.pack_propagate(False)
        
        self.status_var = tk.StringVar(value="Ready")
        ttk.Label(status_frame, 
                 textvariable=self.status_var,
                 style='Title.TLabel').pack(side=tk.LEFT, padx=10)
        
        self.clock_var = tk.StringVar()
        ttk.Label(status_frame, textvariable=self.clock_var,style='Title.TLabel').pack(side=tk.RIGHT, padx=10)
        self.update_clock()
    def update_clock(self):
        """Update clock in status bar"""
        current_time = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
        self.clock_var.set(current_time)
        self.after(1000, self.update_clock)

    def update_data(self):
        """Update all data including processes and graphs"""
        try:
            self.update_processes()
            self.update_graphs()
            self.after(self.update_interval, self.update_data)
        except Exception as e:
            self.status_var.set(f"Error: {str(e)}")
            self.after(self.update_interval, self.update_data)

    def update_processes(self):
        """Update process list"""
        self.process_cache.clear()
        
        for proc in psutil.process_iter(['pid', 'name', 'username', 'cpu_percent', 'memory_info', 'status']):
            try:
                if not self.should_show(proc.info):
                    continue
                    
                info = proc.info
                mem_mb = info['memory_info'].rss // (1024 ** 2)
                
                self.process_cache.append({
                    'pid': info['pid'],
                    'name': info['name'],
                    'user': info['username'],
                    'cpu%': info['cpu_percent'],
                    'memory': f"{mem_mb} MB",
                    'status': info['status']
                })
            except (psutil.NoSuchProcess, psutil.AccessDenied):
                continue
        
        self.refresh_treeview()
        self.status_var.set(f"Processes: {len(self.process_cache)} | Last update: {datetime.now().strftime('%H:%M:%S')}")

    def should_show(self, proc_info):
        """Filter processes based on current settings"""
        filter_mode = self.filter_var.get()
        search_text = self.search_var.get().lower()
        
        if search_text and search_text not in proc_info['name'].lower():
            return False
        
        filter_conditions = {
            "All": True,
            "Your": proc_info['username'] == self.current_user,
            "Non-root": proc_info['username'] != "root",
            "Running": proc_info['status'] == psutil.STATUS_RUNNING
        }
        
        return filter_conditions.get(filter_mode, True)

    def refresh_treeview(self):
        """Refresh the process table"""
        for item in self.tree.get_children():
            self.tree.delete(item)
        
        for proc in self.process_cache:
            self.tree.insert("", "end", values=(
                proc['pid'],
                proc['name'],
                proc['user'],
                f"{proc['cpu%']:.1f}%",
                proc['memory'],
                proc['status']
            ))

    def update_graphs(self):
        """Update system performance graphs"""
        try:
            # Get metrics
            cpu = psutil.cpu_percent()
            mem = psutil.virtual_memory().percent
            disk = psutil.disk_usage('/').percent
            
            current_net = psutil.net_io_counters()
            if hasattr(self, 'last_network'):
                net_speed = (current_net.bytes_recv - self.last_network.bytes_recv) / (1024**2)
            else:
                net_speed = 0
            self.last_network = current_net
            
            # Update data
            for key, val in zip(['cpu', 'mem', 'disk', 'network'], [cpu, mem, disk, net_speed]):
                self.graph_data[key].append(val)
                if len(self.graph_data[key]) > 60:
                    self.graph_data[key] = self.graph_data[key][-60:]
            
            # Update plots
            for ax, line, data, color in [
                (self.ax_cpu, self.cpu_line, self.graph_data['cpu'], '#0896f5'),
                (self.ax_mem, self.mem_line, self.graph_data['mem'], "#25d870"), 
                (self.ax_disk, self.disk_line, self.graph_data['disk'], "#f61b03"),   
                (self.ax_network, self.network_line, self.graph_data['network'], '#1c1c1b')  
            ]:
                line.set_data(range(len(data)), data)
                line.set_color(color)
                ax.relim()
                ax.autoscale_view()
            
            self.canvas.draw()
            
        except Exception as e:
            print(f"Graph error: {e}")

    def kill_process(self):
        """Kill selected process"""
        selected = self.tree.selection()
        if not selected:
            messagebox.showwarning("Warning", "Please select a process first")
            return
            
        pid = int(self.tree.item(selected[0], 'values')[0])
        if messagebox.askyesno("Confirm", f"Kill process {pid}?"):
            try:
                psutil.Process(pid).terminate()
                self.status_var.set(f"Process {pid} terminated")
                self.update_processes()
            except psutil.NoSuchProcess:
                messagebox.showerror("Error", "Process not found")
            except psutil.AccessDenied:
                messagebox.showerror("Error", "Access denied")

    def show_process_details(self, event=None):
        """Show details for selected process"""
        selected = self.tree.selection()
        if selected:
            pid = int(self.tree.item(selected[0], 'values')[0])
            ProcessDetailWindow(self, pid)

    def on_close(self):
        """Handle window close event"""
        plt.close('all')
        self.destroy()

class ProcessDetailWindow(tk.Toplevel):
    def __init__(self, master, pid):
        super().__init__(master)
        self.title(f"Process Details - PID: {pid}")
        self.geometry("1000x700")
        
        try:
            self.proc = psutil.Process(pid)
            self.create_widgets()
        except psutil.NoSuchProcess:
            messagebox.showerror("Error", "Process no longer exists")
            self.destroy()

    def create_widgets(self):
        notebook = ttk.Notebook(self)
        notebook.pack(fill=tk.BOTH, expand=True)
        
        # General Info Tab
        gen_frame = ttk.Frame(notebook)
        self.create_general_info(gen_frame)
        notebook.add(gen_frame, text="General")
        
        # Memory Info Tab
        mem_frame = ttk.Frame(notebook)
        self.create_memory_info(mem_frame)
        notebook.add(mem_frame, text="Memory")
        
        # Connections Tab
        conn_frame = ttk.Frame(notebook)
        self.create_connections(conn_frame)
        notebook.add(conn_frame, text="Connections")

    def create_general_info(self, parent):
        tree = ttk.Treeview(parent, columns=("Property", "Value"), show="headings")
        tree.heading("Property", text="Property")
        tree.heading("Value", text="Value")
        
        try:
            info = self.proc.as_dict()
            for key, value in info.items():
                if isinstance(value, (list, dict)):
                    value = str(value)
                tree.insert("", "end", values=(key, value))
        except psutil.AccessDenied:
            tree.insert("", "end", values=("Error", "Access denied"))
            
        tree.pack(fill=tk.BOTH, expand=True)

    def create_memory_info(self, parent):
        text = scrolledtext.ScrolledText(parent, wrap=tk.WORD)
        text.pack(fill=tk.BOTH, expand=True)
        
        try:
            mem_info = self.proc.memory_full_info()
            for attr in dir(mem_info):
                if not attr.startswith('_'):
                    value = getattr(mem_info, attr)
                    text.insert(tk.END, f"{attr}: {value}\n\n")
        except psutil.AccessDenied:
            text.insert(tk.END, "Access denied to memory information")
        
        text.config(state=tk.DISABLED)

    def create_connections(self, parent):
        tree = ttk.Treeview(parent, columns=("FD", "Family", "Type", "Local", "Remote", "Status"), show="headings")
        for col in tree["columns"]:
            tree.heading(col, text=col)
        
        try:
            conns = self.proc.connections()
            for conn in conns:
                tree.insert("", "end", values=(
                    conn.fd,
                    conn.family,
                    conn.type,
                    f"{conn.laddr.ip}:{conn.laddr.port}" if conn.laddr else "",
                    f"{conn.raddr.ip}:{conn.raddr.port}" if hasattr(conn, 'raddr') and conn.raddr else "",
                    conn.status
                ))
        except psutil.AccessDenied:
            tree.insert("", "end", values=("Access denied", "", "", "", "", ""))
            
        tree.pack(fill=tk.BOTH, expand=True)

if __name__=="__main__":
    app=moderntaskmanager()
    app.mainloop()